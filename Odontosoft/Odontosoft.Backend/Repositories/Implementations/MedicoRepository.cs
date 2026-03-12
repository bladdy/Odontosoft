using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

using Odontosoft.Backend.Services;

namespace Odontosoft.Backend.Repositories.Implementations;

public class MedicoRepository : GenericRepository<Medico>, IMedicoRepository
{
    private readonly DataContext _context;

    public MedicoRepository(DataContext context, ITenantService tenantService) : base(context, tenantService)
    {
        _context = context;
    }

    public async Task<ActionResponse<Medico>> GetMedicoConEspecialidadesAsync(Guid medicoId)
    {
        try
        {
            var medico = await _context.Medicos
                .Include(m => m.Usuario)
                .Include(m => m.MedicoEspecialidades)
                    .ThenInclude(me => me.Especialidad)
                .FirstOrDefaultAsync(m => m.Id == medicoId);

            if (medico == null)
            {
                return new ActionResponse<Medico>
                {
                    WasSuccess = false,
                    Message = "Médico no encontrado"
                };
            }

            return new ActionResponse<Medico>
            {
                WasSuccess = true,
                Result = medico
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<Medico>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<Medico>> GetMedicoConHorariosAsync(Guid medicoId, Guid sucursalId)
    {
        try
        {
            var medico = await _context.Medicos
                .Include(m => m.Usuario)
                .Include(m => m.HorariosMedico.Where(h => h.SucursalId == sucursalId && h.Activo))
                .FirstOrDefaultAsync(m => m.Id == medicoId);

            if (medico == null)
            {
                return new ActionResponse<Medico>
                {
                    WasSuccess = false,
                    Message = "Médico no encontrado"
                };
            }

            return new ActionResponse<Medico>
            {
                WasSuccess = true,
                Result = medico
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<Medico>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<IEnumerable<Medico>>> GetMedicosPorSucursalAsync(Guid sucursalId)
    {
        try
        {
            var medicos = await _context.HorariosMedico
                .Where(h => h.SucursalId == sucursalId && h.Activo)
                .Select(h => h.Medico)
                .Include(m => m.Usuario)
                .Include(m => m.MedicoEspecialidades)
                    .ThenInclude(me => me.Especialidad)
                .Distinct()
                .Where(m => m.Activo)
                .OrderBy(m => m.Usuario.Nombre)
                .ToListAsync();

            return new ActionResponse<IEnumerable<Medico>>
            {
                WasSuccess = true,
                Result = medicos
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<Medico>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<IEnumerable<Medico>>> GetMedicosPorEspecialidadAsync(Guid especialidadId)
    {
        try
        {
            var medicos = await _context.MedicoEspecialidades
                .Where(me => me.EspecialidadId == especialidadId)
                .Select(me => me.Medico)
                .Include(m => m.Usuario)
                .Where(m => m.Activo)
                .OrderBy(m => m.Usuario.Nombre)
                .ToListAsync();

            return new ActionResponse<IEnumerable<Medico>>
            {
                WasSuccess = true,
                Result = medicos
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<Medico>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<Medico>> GetByCedulaAsync(string cedula)
    {
        try
        {
            var medico = await _context.Medicos
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.CedulaProfesional == cedula);

            if (medico == null)
            {
                return new ActionResponse<Medico>
                {
                    WasSuccess = false,
                    Message = "Médico no encontrado"
                };
            }

            return new ActionResponse<Medico>
            {
                WasSuccess = true,
                Result = medico
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<Medico>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }
}