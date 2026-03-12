using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using Odontosoft.Backend.Services;
using Odontosoft.Shared.DTOs;
using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Helpers;
using Odontosoft.Shared.Responses;

namespace Odontosoft.Backend.Repositories.Implementations;

public class PacienteRepository : GenericRepository<Paciente>, IPacienteRepository
{
    private readonly DataContext _context;

    public PacienteRepository(DataContext context, ITenantService tenantService) : base(context, tenantService)
    {
        _context = context;
    }

    public override async Task<ActionResponse<IEnumerable<Paciente>>> GetAsync(PaginationDTO pagination)
    {
        try
        {
            var queryable = _context.Pacientes
                .Include(p => p.Sucursal)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(p =>
                    p.Nombre.Contains(pagination.Filter) ||
                    p.Apellidos.Contains(pagination.Filter) ||
                    p.NumeroExpediente.Contains(pagination.Filter));
            }

            return new ActionResponse<IEnumerable<Paciente>>
            {
                WasSuccess = true,
                Result = await queryable
                    .OrderBy(p => p.Apellidos)
                    .ThenBy(p => p.Nombre)
                    .Paginate(pagination)
                    .ToListAsync()
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<Paciente>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<Paciente>> GetPacienteCompletoAsync(Guid pacienteId)
    {
        try
        {
            var paciente = await _context.Pacientes
                .Include(p => p.Sucursal).ThenInclude(s => s.Clinica)
                .Include(p => p.Alergias.Where(a => a.Activo))
                .Include(p => p.Antecedentes.Where(a => a.Activo))
                .FirstOrDefaultAsync(p => p.Id == pacienteId);

            if (paciente == null)
            {
                return new ActionResponse<Paciente>
                {
                    WasSuccess = false,
                    Message = "Paciente no encontrado"
                };
            }

            return new ActionResponse<Paciente>
            {
                WasSuccess = true,
                Result = paciente
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<Paciente>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<IEnumerable<Paciente>>> BuscarPacientesAsync(Guid sucursalId, string termino)
    {
        try
        {
            var pacientes = await _context.Pacientes
                .Where(p => p.SucursalId == sucursalId &&
                           p.Activo &&
                           (p.Nombre.Contains(termino) ||
                            p.Apellidos.Contains(termino) ||
                            p.NumeroExpediente.Contains(termino) ||
                            (p.CURP != null && p.CURP.Contains(termino))))
                .OrderBy(p => p.Apellidos)
                .ThenBy(p => p.Nombre)
                .Take(50)
                .ToListAsync();

            return new ActionResponse<IEnumerable<Paciente>>
            {
                WasSuccess = true,
                Result = pacientes
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<Paciente>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<Paciente>> GetByNumeroExpedienteAsync(Guid sucursalId, string numeroExpediente)
    {
        try
        {
            var paciente = await _context.Pacientes
                .FirstOrDefaultAsync(p => p.SucursalId == sucursalId &&
                                        p.NumeroExpediente == numeroExpediente);

            if (paciente == null)
            {
                return new ActionResponse<Paciente>
                {
                    WasSuccess = false,
                    Message = "Paciente no encontrado"
                };
            }

            return new ActionResponse<Paciente>
            {
                WasSuccess = true,
                Result = paciente
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<Paciente>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<Paciente>> GetByCURPAsync(string curp)
    {
        try
        {
            var paciente = await _context.Pacientes
                .FirstOrDefaultAsync(p => p.CURP == curp);

            if (paciente == null)
            {
                return new ActionResponse<Paciente>
                {
                    WasSuccess = false,
                    Message = "Paciente no encontrado"
                };
            }

            return new ActionResponse<Paciente>
            {
                WasSuccess = true,
                Result = paciente
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<Paciente>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<IEnumerable<Paciente>>> GetPacientesConAlergiasCriticasAsync(Guid sucursalId)
    {
        try
        {
            var pacientes = await _context.Pacientes
                .Include(p => p.Alergias)
                .Where(p => p.SucursalId == sucursalId &&
                           p.Activo &&
                           p.Alergias.Any(a => a.Gravedad == "Grave" && a.Activo))
                .ToListAsync();

            return new ActionResponse<IEnumerable<Paciente>>
            {
                WasSuccess = true,
                Result = pacientes
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<Paciente>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<string>> GenerarNumeroExpedienteAsync(Guid sucursalId)
    {
        try
        {
            var ultimoPaciente = await _context.Pacientes
                .Where(p => p.SucursalId == sucursalId)
                .OrderByDescending(p => p.Id)
                .Select(p => p.NumeroExpediente)
                .FirstOrDefaultAsync();

            int numero = 1;
            if (!string.IsNullOrEmpty(ultimoPaciente))
            {
                var partes = ultimoPaciente.Split('-');
                if (partes.Length > 1 && int.TryParse(partes[1], out int ultimoNumero))
                {
                    numero = ultimoNumero + 1;
                }
            }

            return new ActionResponse<string>
            {
                WasSuccess = true,
                Result = $"PAC-{numero:D6}"
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