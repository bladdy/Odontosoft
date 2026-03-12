using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

using Odontosoft.Backend.Services;

namespace Odontosoft.Backend.Repositories.Implementations;

public class TratamientoOrtodonciaRepository : GenericRepository<TratamientoOrtodoncia>, ITratamientoOrtodonciaRepository
{
    private readonly DataContext _context;

    public TratamientoOrtodonciaRepository(DataContext context, ITenantService tenantService) : base(context, tenantService)
    {
        _context = context;
    }

    public async Task<ActionResponse<TratamientoOrtodoncia>> GetTratamientoCompletoAsync(Guid tratamientoId)
    {
        try
        {
            var tratamiento = await _context.TratamientosOrtodoncia
                .Include(t => t.Paciente)
                .Include(t => t.Medico).ThenInclude(m => m.Usuario)
                .Include(t => t.Controles)
                .FirstOrDefaultAsync(t => t.Id == tratamientoId);

            if (tratamiento == null)
            {
                return new ActionResponse<TratamientoOrtodoncia>
                {
                    WasSuccess = false,
                    Message = "Tratamiento de ortodoncia no encontrado"
                };
            }

            return new ActionResponse<TratamientoOrtodoncia>
            {
                WasSuccess = true,
                Result = tratamiento
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<TratamientoOrtodoncia>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<IEnumerable<TratamientoOrtodoncia>>> GetTratamientosActivosAsync(Guid medicoId)
    {
        try
        {
            var tratamientos = await _context.TratamientosOrtodoncia
                .Include(t => t.Paciente)
                .Where(t => t.MedicoId == medicoId && t.Estado == "Activo")
                .OrderBy(t => t.FechaInicio)
                .ToListAsync();

            return new ActionResponse<IEnumerable<TratamientoOrtodoncia>>
            {
                WasSuccess = true,
                Result = tratamientos
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<TratamientoOrtodoncia>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<TratamientoOrtodoncia>> GetTratamientoActivoPacienteAsync(Guid pacienteId)
    {
        try
        {
            var tratamiento = await _context.TratamientosOrtodoncia
                .Include(t => t.Medico).ThenInclude(m => m.Usuario)
                .Include(t => t.Controles)
                .Where(t => t.PacienteId == pacienteId && t.Estado == "Activo")
                .FirstOrDefaultAsync();

            if (tratamiento == null)
            {
                return new ActionResponse<TratamientoOrtodoncia>
                {
                    WasSuccess = false,
                    Message = "No hay tratamiento de ortodoncia activo para este paciente"
                };
            }

            return new ActionResponse<TratamientoOrtodoncia>
            {
                WasSuccess = true,
                Result = tratamiento
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<TratamientoOrtodoncia>
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
            var ultimoTratamiento = await _context.TratamientosOrtodoncia
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
                Result = $"ORT-{DateTime.Now:yyyyMM}-{numero:D6}"
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