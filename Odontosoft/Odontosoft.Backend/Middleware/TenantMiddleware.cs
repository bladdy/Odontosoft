using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using Odontosoft.Backend.Services;

namespace Odontosoft.Backend.Middleware;

public class TenantMiddleware
{
    private readonly RequestDelegate _next;

    public TenantMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(
        HttpContext context,
        DataContext dbContext,
        ITenantService tenantService)
    {
        var host = context.Request.Host.Host;

        var subdomain = host.Split('.').FirstOrDefault();

        if (!string.IsNullOrWhiteSpace(subdomain))
        {
            var tenant = await dbContext.Tenants
                .AsNoTracking()
                .FirstOrDefaultAsync(t =>
                    t.Subdomain.ToLower() == subdomain.ToLower());

            if (tenant != null)
            {
                tenantService.SetTenant(tenant);
            }
        }

        await _next(context);
    }
}