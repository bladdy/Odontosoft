using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Enums;

namespace Odontosoft.Backend.Services;

public class BillingService
{
    private readonly DataContext _context;

    public BillingService(DataContext context)
    {
        _context = context;
    }

    public async Task GenerarFacturaMensual(Guid tenantId)
    {
        var tenant = await _context.Tenants
            .Include(t => t.CurrentSubscription!)
            .ThenInclude(s => s.Plan)
            .FirstAsync(t => t.Id == tenantId);

        var plan = tenant.CurrentSubscription!.Plan;

        var sucursales = await _context.Sucursales
            .CountAsync(s => s.TenantId == tenantId);

        decimal total = plan.PrecioBase;

        if (sucursales > plan.SucursalesIncluidas)
        {
            int extras = sucursales - plan.SucursalesIncluidas;
            total += extras * plan.PrecioPorSucursalExtra;
        }

        var pago = new PagoSubscription
        {
            SubscriptionId = tenant.CurrentSubscription.Id,
            Monto = total,
            FechaPago = DateTime.UtcNow,
            MetodoPago = "Pendiente",
            Status = PagoStatus.Pendiente
        };

        _context.PagoSubscriptions.Add(pago);
        await _context.SaveChangesAsync();
    }
}