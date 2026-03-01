using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using Odontosoft.Backend.Repositories.Interfaces;
using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

namespace Odontosoft.Backend.Repositories.Implementations;

public class PresupuestoDentalRepository : GenericRepository<PresupuestoDental>, IPresupuestoDentalRepository
{
    private readonly DataContext _context;

    public PresupuestoDentalRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ActionResponse<PresupuestoDental>> GetPresupuestoCompletoAsync(int presupuestoId)
    {
        try
        {
            var presupuesto = await _context.PresupuestosDentales
                .Include(p => p.Paciente)
                .Include(p => p.Medico).ThenInclude(m => m.Usuario)
                .Include(p => p.Sucursal)
                .Include(p => p.Detalles)
                .FirstOrDefaultAsync(p => p.Id == presupuestoId);

            if (presupuesto == null)
            {
                return new ActionResponse<PresupuestoDental>
                {
                    WasSuccess = false,
                    Message = "Presupuesto no encontrado"
                };
            }

            return new ActionResponse<PresupuestoDental>
            {
                WasSuccess = true,
                Result = presupuesto
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<PresupuestoDental>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<IEnumerable<PresupuestoDental>>> GetPresupuestosPacienteAsync(int pacienteId)
    {
        try
        {
            var presupuestos = await _context.PresupuestosDentales
                .Include(p => p.Medico).ThenInclude(m => m.Usuario)
                .Include(p => p.Sucursal)
                .Where(p => p.PacienteId == pacienteId)
                .OrderByDescending(p => p.FechaEmision)
                .ToListAsync();

            return new ActionResponse<IEnumerable<PresupuestoDental>>
            {
                WasSuccess = true,
                Result = presupuestos
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<PresupuestoDental>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<IEnumerable<PresupuestoDental>>> GetPresupuestosPorEstadoAsync(int sucursalId, string estado)
    {
        try
        {
            var presupuestos = await _context.PresupuestosDentales
                .Include(p => p.Paciente)
                .Include(p => p.Medico).ThenInclude(m => m.Usuario)
                .Where(p => p.SucursalId == sucursalId && p.Estado == estado)
                .OrderByDescending(p => p.FechaEmision)
                .ToListAsync();

            return new ActionResponse<IEnumerable<PresupuestoDental>>
            {
                WasSuccess = true,
                Result = presupuestos
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<PresupuestoDental>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<string>> GenerarNumeroPresupuestoAsync(int sucursalId)
    {
        try
        {
            var ultimoPresupuesto = await _context.PresupuestosDentales
                .Where(p => p.SucursalId == sucursalId)
                .OrderByDescending(p => p.Id)
                .Select(p => p.NumeroPresupuesto)
                .FirstOrDefaultAsync();

            int numero = 1;
            if (!string.IsNullOrEmpty(ultimoPresupuesto))
            {
                var partes = ultimoPresupuesto.Split('-');
                if (partes.Length > 2 && int.TryParse(partes[2], out int ultimoNumero))
                {
                    numero = ultimoNumero + 1;
                }
            }

            return new ActionResponse<string>
            {
                WasSuccess = true,
                Result = $"PRE-{DateTime.Now:yyyyMM}-{numero:D6}"
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

    public async Task<ActionResponse<bool>> AprobarPresupuestoAsync(int presupuestoId)
    {
        try
        {
            var presupuesto = await _context.PresupuestosDentales.FindAsync(presupuestoId);

            if (presupuesto == null)
            {
                return new ActionResponse<bool>
                {
                    WasSuccess = false,
                    Message = "Presupuesto no encontrado"
                };
            }

            presupuesto.Estado = "Aprobado";
            presupuesto.FechaAprobacion = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new ActionResponse<bool>
            {
                WasSuccess = true,
                Result = true
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<bool>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }
}