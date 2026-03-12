using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using Odontosoft.Backend.Services;
using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

namespace Odontosoft.Backend.Repositories.Implementations;

public class ConsultaRepository : GenericRepository<Consulta>, IConsultaRepository
{
    private readonly DataContext _context;

    public ConsultaRepository(DataContext context, ITenantService tenantService) : base(context, tenantService)
    {
        _context = context;
    }

    public async Task<ActionResponse<Consulta>> GetConsultaCompletaAsync(Guid consultaId)
    {
        try
        {
            var consulta = await _context.Consultas
                .Include(c => c.Paciente)
                .Include(c => c.Medico).ThenInclude(m => m.Usuario)
                .Include(c => c.Cita)
                .Include(c => c.Recetas).ThenInclude(r => r.RecetaDetalles)
                .Include(c => c.OrdenesLaboratorio).ThenInclude(o => o.OrdenLaboratorioDetalles)
                .Include(c => c.OrdenesImagen).ThenInclude(o => o.OrdenImagenDetalles)
                .FirstOrDefaultAsync(c => c.Id == consultaId);

            if (consulta == null)
            {
                return new ActionResponse<Consulta>
                {
                    WasSuccess = false,
                    Message = "Consulta no encontrada"
                };
            }

            return new ActionResponse<Consulta>
            {
                WasSuccess = true,
                Result = consulta
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<Consulta>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<IEnumerable<Consulta>>> GetConsultasPacienteAsync(Guid pacienteId)
    {
        try
        {
            var consultas = await _context.Consultas
                .Include(c => c.Medico).ThenInclude(m => m.Usuario)
                .Where(c => c.PacienteId == pacienteId)
                .OrderByDescending(c => c.FechaConsulta)
                .ToListAsync();

            return new ActionResponse<IEnumerable<Consulta>>
            {
                WasSuccess = true,
                Result = consultas
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<Consulta>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<IEnumerable<Consulta>>> GetConsultasMedicoAsync(Guid medicoId, DateTime? fechaInicio = null)
    {
        try
        {
            var query = _context.Consultas
                .Include(c => c.Paciente)
                .Where(c => c.MedicoId == medicoId);

            if (fechaInicio.HasValue)
            {
                query = query.Where(c => c.FechaConsulta >= fechaInicio.Value);
            }

            var consultas = await query
                .OrderByDescending(c => c.FechaConsulta)
                .ToListAsync();

            return new ActionResponse<IEnumerable<Consulta>>
            {
                WasSuccess = true,
                Result = consultas
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<Consulta>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<string>> GenerarNumeroConsultaAsync()
    {
        try
        {
            var ultimaConsulta = await _context.Consultas
                .OrderByDescending(c => c.Id)
                .Select(c => c.NumeroConsulta)
                .FirstOrDefaultAsync();

            int numero = 1;
            if (!string.IsNullOrEmpty(ultimaConsulta))
            {
                var partes = ultimaConsulta.Split('-');
                if (partes.Length > 2 && int.TryParse(partes[2], out int ultimoNumero))
                {
                    numero = ultimoNumero + 1;
                }
            }

            return new ActionResponse<string>
            {
                WasSuccess = true,
                Result = $"CON-{DateTime.Now:yyyyMM}-{numero:D6}"
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