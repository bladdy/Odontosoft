using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using Odontosoft.Backend.Services;
using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

namespace Odontosoft.Backend.Repositories.Implementations;

public class CitaRepository : GenericRepository<Cita>, ICitaRepository
{
    private readonly DataContext _context;

    public CitaRepository(
        DataContext context,
        ITenantService tenantService)
        : base(context, tenantService)
    {
        _context = context;
    }

    public async Task<ActionResponse<IEnumerable<Cita>>> GetAgendaMedicoAsync(Guid medicoId, DateTime fecha)
    {
        try
        {
            var fechaInicio = fecha.Date;
            var fechaFin = fecha.Date.AddDays(1);

            var citas = await _context.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Consultorio)
                .Where(c => c.MedicoId == medicoId &&
                           c.FechaHora >= fechaInicio &&
                           c.FechaHora < fechaFin)
                .OrderBy(c => c.FechaHora)
                .ToListAsync();

            return new ActionResponse<IEnumerable<Cita>>
            {
                WasSuccess = true,
                Result = citas
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<Cita>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<IEnumerable<Cita>>> GetCitasPacienteAsync(Guid pacienteId, DateTime? fechaInicio = null)
    {
        try
        {
            var query = _context.Citas
                .Include(c => c.Medico).ThenInclude(m => m.Usuario)
                .Include(c => c.Consultorio)
                .Where(c => c.PacienteId == pacienteId);

            if (fechaInicio.HasValue)
            {
                query = query.Where(c => c.FechaHora >= fechaInicio.Value);
            }

            var citas = await query
                .OrderByDescending(c => c.FechaHora)
                .ToListAsync();

            return new ActionResponse<IEnumerable<Cita>>
            {
                WasSuccess = true,
                Result = citas
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<Cita>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<bool>> HorarioDisponibleAsync(Guid medicoId, DateTime fechaHora, int duracionMinutos)
    {
        try
        {
            var fechaFin = fechaHora.AddMinutes(duracionMinutos);

            var citaConflicto = await _context.Citas
                .Where(c => c.MedicoId == medicoId &&
                           c.EstadoCita != "Cancelada" &&
                           ((c.FechaHora >= fechaHora && c.FechaHora < fechaFin) ||
                            (c.FechaHora.AddMinutes(c.DuracionMinutos) > fechaHora && c.FechaHora < fechaHora)))
                .AnyAsync();

            if (citaConflicto)
            {
                return new ActionResponse<bool>
                {
                    WasSuccess = false,
                    Message = "El horario no está disponible, hay un conflicto con otra cita"
                };
            }

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

    public async Task<ActionResponse<IEnumerable<Cita>>> GetCitasPorEstadoAsync(Guid sucursalId, string estado, DateTime? fecha = null)
    {
        try
        {
            var query = _context.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Medico).ThenInclude(m => m.Usuario)
                .Include(c => c.Consultorio)
                .Where(c => c.SucursalId == sucursalId && c.EstadoCita == estado);

            if (fecha.HasValue)
            {
                var fechaInicio = fecha.Value.Date;
                var fechaFin = fecha.Value.Date.AddDays(1);
                query = query.Where(c => c.FechaHora >= fechaInicio && c.FechaHora < fechaFin);
            }

            var citas = await query
                .OrderBy(c => c.FechaHora)
                .ToListAsync();

            return new ActionResponse<IEnumerable<Cita>>
            {
                WasSuccess = true,
                Result = citas
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<Cita>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<Cita>> GetCitaConDetallesAsync(Guid citaId)
    {
        try
        {
            var cita = await _context.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Medico).ThenInclude(m => m.Usuario)
                .Include(c => c.Consultorio)
                .Include(c => c.Sucursal)
                .Include(c => c.Consulta)
                .FirstOrDefaultAsync(c => c.Id == citaId);

            if (cita == null)
            {
                return new ActionResponse<Cita>
                {
                    WasSuccess = false,
                    Message = "Cita no encontrada"
                };
            }

            return new ActionResponse<Cita>
            {
                WasSuccess = true,
                Result = cita
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<Cita>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<string>> GenerarNumeroCitaAsync(Guid sucursalId)
    {
        try
        {
            var ultimaCita = await _context.Citas
                .Where(c => c.SucursalId == sucursalId)
                .OrderByDescending(c => c.Id)
                .Select(c => c.NumeroCita)
                .FirstOrDefaultAsync();

            int numero = 1;
            if (!string.IsNullOrEmpty(ultimaCita))
            {
                var partes = ultimaCita.Split('-');
                if (partes.Length > 2 && int.TryParse(partes[2], out int ultimoNumero))
                {
                    numero = ultimoNumero + 1;
                }
            }

            return new ActionResponse<string>
            {
                WasSuccess = true,
                Result = $"CIT-{DateTime.Now:yyyyMM}-{numero:D6}"
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
}