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

    public async Task Invoke(HttpContext context, ITenantService tenantService, DataContext db)
    {
        if (tenantService.TenantId != Guid.Empty)
        {
            var tenant = await db.Tenants
                .Include(t => t.CurrentSubscription)
                .FirstOrDefaultAsync(t => t.Id == tenantService.TenantId);

            if (tenant == null || tenant.Status != TenantStatus.Active)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Suscripción inactiva.");
                return;
            }

            if (tenant.CurrentSubscription!.FechaFin < DateTime.UtcNow)
            {
                tenant.Status = TenantStatus.Suspended;
                await db.SaveChangesAsync();

                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Suscripción vencida.");
                return;
            }
        }

        await _next(context);
    }
}