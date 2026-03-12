using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using Odontosoft.Backend.Repositories.Interfaces;
using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

using Odontosoft.Backend.Services;

namespace Odontosoft.Backend.Repositories.Implementations;

public class TratamientoDentalRepository : GenericRepository<TratamientoDental>, ITratamientoDentalRepository
{
    private readonly DataContext _context;

    public TratamientoDentalRepository(DataContext context, ITenantService tenantService) : base(context, tenantService)
    {
        _context = context;
    }

    public async Task<ActionResponse<TratamientoDental>> GetTratamientoCompletoAsync(Guid tratamientoId)
    {
        try
        {
            var tratamiento = await _context.TratamientosDentales
                .Include(t => t.Paciente)
                .Include(t => t.Medico).ThenInclude(m => m.Usuario)
                .Include(t => t.Consulta)
                .Include(t => t.DienteEstado)
                .Include(t => t.Seguimientos).ThenInclude(s => s.Medico).ThenInclude(m => m.Usuario)
                .FirstOrDefaultAsync(t => t.Id == tratamientoId);

            if (tratamiento == null)
            {
                return new ActionResponse<TratamientoDental>
                {
                    WasSuccess = false,
                    Message = "Tratamiento no encontrado"
                };
            }

            return new ActionResponse<TratamientoDental>
            {
                WasSuccess = true,
                Result = tratamiento
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<TratamientoDental>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<IEnumerable<TratamientoDental>>> GetTratamientosPacienteAsync(Guid pacienteId)
    {
        try
        {
            var tratamientos = await _context.TratamientosDentales
                .Include(t => t.Medico).ThenInclude(m => m.Usuario)
                .Where(t => t.PacienteId == pacienteId)
                .OrderByDescending(t => t.FechaTratamiento)
                .ToListAsync();

            return new ActionResponse<IEnumerable<TratamientoDental>>
            {
                WasSuccess = true,
                Result = tratamientos
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<TratamientoDental>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<IEnumerable<TratamientoDental>>> GetTratamientosActivosAsync(Guid medicoId)
    {
        try
        {
            var tratamientos = await _context.TratamientosDentales
                .Include(t => t.Paciente)
                .Where(t => t.MedicoId == medicoId &&
                       (t.Estado == "EnProceso" || t.Estado == "Programado"))
                .OrderBy(t => t.FechaProximaCita ?? t.FechaTratamiento)
                .ToListAsync();

            return new ActionResponse<IEnumerable<TratamientoDental>>
            {
                WasSuccess = true,
                Result = tratamientos
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<TratamientoDental>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<IEnumerable<TratamientoDental>>> GetTratamientosPorEstadoAsync(Guid sucursalId, string estado)
    {
        try
        {
            var tratamientos = await _context.TratamientosDentales
                .Include(t => t.Paciente)
                .Include(t => t.Medico).ThenInclude(m => m.Usuario)
                .Where(t => t.Paciente.SucursalId == sucursalId && t.Estado == estado)
                .OrderByDescending(t => t.FechaTratamiento)
                .ToListAsync();

            return new ActionResponse<IEnumerable<TratamientoDental>>
            {
                WasSuccess = true,
                Result = tratamientos
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<TratamientoDental>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<string>> GenerarNumeroTratamientoAsync()
    {
        try
        {
            var ultimoTratamiento = await _context.TratamientosDentales
                .OrderByDescending(t => t.Id)
                .Select(t => t.NumeroTratamiento)
                .FirstOrDefaultAsync();

            int numero = 1;
            if (!string.IsNullOrEmpty(ultimoTratamiento))
            {
                var partes = ultimoTratamiento.Split('-');
                if (partes.Length > 2 && int.TryParse(partes[2], out int ultimoNumero))
                {
                    numero = ultimoNumero + 1;
                }
            }

            return new ActionResponse<string>
            {
                WasSuccess = true,
                Result = $"TRT-{DateTime.Now:yyyyMM}-{numero:D6}"
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