using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

namespace Odontosoft.Backend.Repositories.Implementations;

public class FacturaRepository : GenericRepository<Factura>, IFacturaRepository
{
    private readonly DataContext _context;

    public FacturaRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ActionResponse<Factura>> GetFacturaConDetallesAsync(Guid facturaId)
    {
        try
        {
            var factura = await _context.Facturas
                .Include(f => f.Paciente)
                .Include(f => f.Sucursal)
                .Include(f => f.Cita)
                .Include(f => f.FacturaDetalles).ThenInclude(fd => fd.Servicio)
                .Include(f => f.Pagos)
                .FirstOrDefaultAsync(f => f.Id == facturaId);

            if (factura == null)
            {
                return new ActionResponse<Factura>
                {
                    WasSuccess = false,
                    Message = "Factura no encontrada"
                };
            }

            return new ActionResponse<Factura>
            {
                WasSuccess = true,
                Result = factura
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<Factura>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<IEnumerable<Factura>>> GetFacturasPacienteAsync(Guid pacienteId)
    {
        try
        {
            var facturas = await _context.Facturas
                .Include(f => f.Sucursal)
                .Where(f => f.PacienteId == pacienteId)
                .OrderByDescending(f => f.FechaEmision)
                .ToListAsync();

            return new ActionResponse<IEnumerable<Factura>>
            {
                WasSuccess = true,
                Result = facturas
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<Factura>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<IEnumerable<Factura>>> GetFacturasPorEstadoAsync(Guid sucursalId, string estado)
    {
        try
        {
            var facturas = await _context.Facturas
                .Include(f => f.Paciente)
                .Where(f => f.SucursalId == sucursalId && f.Estado == estado)
                .OrderByDescending(f => f.FechaEmision)
                .ToListAsync();

            return new ActionResponse<IEnumerable<Factura>>
            {
                WasSuccess = true,
                Result = facturas
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<Factura>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<IEnumerable<Factura>>> GetFacturasPendientesPagoAsync(Guid sucursalId)
    {
        try
        {
            var facturas = await _context.Facturas
                .Include(f => f.Paciente)
                .Where(f => f.SucursalId == sucursalId &&
                           (f.Estado == "Pendiente" || f.Estado == "Parcial"))
                .OrderBy(f => f.FechaEmision)
                .ToListAsync();

            return new ActionResponse<IEnumerable<Factura>>
            {
                WasSuccess = true,
                Result = facturas
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<Factura>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<string>> GenerarNumeroFacturaAsync(Guid sucursalId)
    {
        try
        {
            var ultimaFactura = await _context.Facturas
                .Where(f => f.SucursalId == sucursalId)
                .OrderByDescending(f => f.Id)
                .Select(f => f.NumeroFactura)
                .FirstOrDefaultAsync();

            int numero = 1;
            if (!string.IsNullOrEmpty(ultimaFactura))
            {
                var partes = ultimaFactura.Split('-');
                if (partes.Length > 2 && int.TryParse(partes[2], out int ultimoNumero))
                {
                    numero = ultimoNumero + 1;
                }
            }

            return new ActionResponse<string>
            {
                WasSuccess = true,
                Result = $"FAC-{DateTime.Now:yyyyMM}-{numero:D6}"
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<string>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<decimal>> GetTotalFacturadoAsync(Guid sucursalId, DateTime fechaInicio, DateTime fechaFin)
    {
        try
        {
            var total = await _context.Facturas
                .Where(f => f.SucursalId == sucursalId &&
                           f.FechaEmision >= fechaInicio &&
                           f.FechaEmision <= fechaFin &&
                           f.Estado != "Cancelada")
                .SumAsync(f => f.Total);

            return new ActionResponse<decimal>
            {
                WasSuccess = true,
                Result = total
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<decimal>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }
}