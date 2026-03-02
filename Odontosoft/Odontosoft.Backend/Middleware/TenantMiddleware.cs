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

        // 🔥 MODO DESARROLLO
        if (host.Contains("localhost"))
        {
            subdomain = "demo";
        }

        if (string.IsNullOrWhiteSpace(subdomain))
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Subdomain requerido.");
            return;
        }

        var tenant = await dbContext.Tenants
            .AsNoTracking()
            .FirstOrDefaultAsync(t =>
                t.Subdomain.ToLower() == subdomain.ToLower());

        if (tenant == null)
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("Tenant no encontrado.");
            return;
        }

        // Si hay JWT validamos coincidencia
        var tenantClaim = context.User?.FindFirst("tenantId")?.Value;

        if (!string.IsNullOrEmpty(tenantClaim))
        {
            if (tenantClaim != tenant.Id.ToString())
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync(
                    "El tenant del token no coincide con el subdominio.");
                return;
            }
        }

        tenantService.SetTenant(tenant);

        await _next(context);
    }
}