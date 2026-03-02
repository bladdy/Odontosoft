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

    public async Task Invoke(
        HttpContext context,
        ITenantService tenantService,
        DataContext dbContext)
    {
        var subdomain = context.Request.Headers["X-Tenant"].FirstOrDefault();

        if (string.IsNullOrEmpty(subdomain))
            throw new Exception("Tenant no especificado");

        var tenant = await dbContext.Tenants
            .FirstOrDefaultAsync(t => t.Subdomain == subdomain && t.IsActive);

        if (tenant == null)
            throw new Exception("Tenant no encontrado");

        tenantService.SetTenant(tenant.Id, tenant.Subdomain);

        await _next(context);
    }
}