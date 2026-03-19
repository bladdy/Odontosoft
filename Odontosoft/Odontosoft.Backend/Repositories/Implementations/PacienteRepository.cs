using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using Odontosoft.Backend.Services;
using Odontosoft.Shared.DTOs;
using Odontosoft.Shared.DTOs.Paciente;
using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Helpers;
using Odontosoft.Shared.Responses;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

    public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
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
            double totalRecords = await queryable.CountAsync();
            var total = (int)Math.Ceiling(totalRecords / pagination.RecordsNumber);
            return new ActionResponse<int>
            {
                WasSuccess = true,
                Result = total
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<int>
            {
                WasSuccess = false,
                Result = 0
            };
        }
    }

    public async Task<ActionResponse<Paciente>> GetPacienteCompletoAsync(Guid pacienteId)
    {
        try
        {
            var paciente = await _context.Pacientes
                .Include(p => p.Sucursal).ThenInclude(s => s.Clinica)
                .Include(p => p.Citas)
                .ThenInclude(p => p.Consulta)
                .ThenInclude(p => p.Medico)
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

    public async Task<ActionResponse<Paciente>> AddFullAsync(PacienteCreateDTO paciente)
    {
        try
        {
            var newPaciente = new Paciente
            {
                Id = Guid.NewGuid(),
                TenantId = _tenantService.TenantId,
                SucursalId = paciente.SucursalId,
                NumeroExpediente = paciente.NumeroExpediente,
                Nombre = paciente.Nombre,
                Apellidos = paciente.Apellidos,
                FechaNacimiento = paciente.FechaNacimiento,
                Ocupacion = paciente.Ocupacion,
                CodigoPostal = paciente.CodigoPostal,
                EstadoCivil = paciente.EstadoCivil,
                GrupoSanguineo = paciente.GrupoSanguineo,
                Sexo = paciente.Sexo,
                CURP = paciente.CURP,
                RFC = paciente.RFC,
                Email = paciente.Email,
                Telefono = paciente.Telefono,
                ContactoEmergencia = paciente.ContactoEmergencia,
                TelefonoEmergencia = paciente.TelefonoEmergencia,
                Direccion = paciente.Direccion,
                Ciudad = paciente.Ciudad,
                Estado = paciente.Estado,
                Foto = paciente.Foto,
                FechaRegistro = DateTime.UtcNow,
                Activo = paciente.Activo
            };
            _context.Pacientes.Add(newPaciente);
            await _context.SaveChangesAsync();
            return new ActionResponse<Paciente>
            {
                WasSuccess = true,
                Result = newPaciente
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<Paciente>
            {
                WasSuccess = false,
                Message = $"Error al crear el paciente."
            };
        }
    }

    public async Task<ActionResponse<Paciente>> UpdateFullAsync(PacienteUpdateDTO paciente)
    {
        try
        {
            var existingPaciente = await _context.Pacientes.FindAsync(paciente.Id);
            if (existingPaciente == null)
            {
                return new ActionResponse<Paciente>
                {
                    WasSuccess = false,
                    Message = "Paciente no encontrado"
                };
            }
            existingPaciente.SucursalId = paciente.SucursalId;
            existingPaciente.NumeroExpediente = paciente.NumeroExpediente;
            existingPaciente.Nombre = paciente.Nombre;
            existingPaciente.Apellidos = paciente.Apellidos;
            existingPaciente.FechaNacimiento = paciente.FechaNacimiento;
            existingPaciente.Ocupacion = paciente.Ocupacion;
            existingPaciente.CodigoPostal = paciente.CodigoPostal;
            existingPaciente.EstadoCivil = paciente.EstadoCivil;
            existingPaciente.GrupoSanguineo = paciente.GrupoSanguineo;
            existingPaciente.Sexo = paciente.Sexo;
            existingPaciente.CURP = paciente.CURP;
            existingPaciente.RFC = paciente.RFC;
            existingPaciente.Email = paciente.Email;
            existingPaciente.Telefono = paciente.Telefono;
            existingPaciente.ContactoEmergencia = paciente.ContactoEmergencia;
            existingPaciente.TelefonoEmergencia = paciente.TelefonoEmergencia;
            existingPaciente.Direccion = paciente.Direccion;
            existingPaciente.Ciudad = paciente.Ciudad;
            existingPaciente.Estado = paciente.Estado;
            existingPaciente.Foto = paciente.Foto;
            existingPaciente.Activo = paciente.Activo;

            _context.Pacientes.Update(existingPaciente);
            await _context.SaveChangesAsync();
            return new ActionResponse<Paciente>
            {
                WasSuccess = true,
                Result = existingPaciente
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<Paciente>
            {
                WasSuccess = false,
                Message = $"Error al actualizar el paciente."
            };
        }
    }

    public async Task<ActionResponse<bool>> InactivateAsync(Guid pacienteId)
    {
        try
        {
            var existingPaciente = await _context.Pacientes.FindAsync(pacienteId);
            if (existingPaciente == null)
            {
                return new ActionResponse<bool>
                {
                    WasSuccess = false,
                    Message = "Paciente no encontrado",
                    Result = false
                };
            }
            existingPaciente.Activo = !existingPaciente.Activo;
            _context.Pacientes.Update(existingPaciente);
            await _context.SaveChangesAsync();
            return new ActionResponse<bool>
            {
                WasSuccess = true,
                Result = true
            };
        }
        catch (Exception)
        {
            return new ActionResponse<bool>
            {
                WasSuccess = false,
                Message = $"Error al actualizar el paciente.",
                Result = false
            };
        }
    }
}