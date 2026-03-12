using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using Odontosoft.Backend.Services;
using Odontosoft.Shared.Enums;

namespace Odontosoft.Backend.Middleware;

public class TenantAccessMiddleware
{
    private readonly RequestDelegate _next;

    public TenantAccessMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, DataContext dbContext, ITenantService tenantService)
    {
        if (context.Request.Path.StartsWithSegments("/swagger"))
        {
            await _next(context);
            return;
        }

        var host = context.Request.Host.Host;

        var subdomain = host.Contains("localhost")
            ? "demo"
            : host.Split('.').FirstOrDefault();

        var tenant = await dbContext.Tenants
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Subdomain == subdomain);

        if (tenant == null)
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("Tenant no encontrado.");
            return;
        }

        tenantService.SetTenant(tenant);

        await _next(context);
    }
}