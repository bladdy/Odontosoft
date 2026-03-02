using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

namespace Odontosoft.Backend.Repositories.Implementations;

public class ExamenPeriodontalRepository : GenericRepository<ExamenPeriodontal>, IExamenPeriodontalRepository
{
    private readonly DataContext _context;

    public ExamenPeriodontalRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ActionResponse<ExamenPeriodontal>> GetExamenCompletoAsync(Guid examenId)
    {
        try
        {
            var examen = await _context.ExamenesPeriodontales
                .Include(e => e.Paciente)
                .Include(e => e.Medico).ThenInclude(m => m.Usuario)
                .Include(e => e.BolsasPeriodontales)
                .FirstOrDefaultAsync(e => e.Id == examenId);

            if (examen == null)
            {
                return new ActionResponse<ExamenPeriodontal>
                {
                    WasSuccess = false,
                    Message = "Examen periodontal no encontrado"
                };
            }

            return new ActionResponse<ExamenPeriodontal>
            {
                WasSuccess = true,
                Result = examen
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<ExamenPeriodontal>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<IEnumerable<ExamenPeriodontal>>> GetExamenesPacienteAsync(Guid pacienteId)
    {
        try
        {
            var examenes = await _context.ExamenesPeriodontales
                .Include(e => e.Medico).ThenInclude(m => m.Usuario)
                .Where(e => e.PacienteId == pacienteId)
                .OrderByDescending(e => e.FechaExamen)
                .ToListAsync();

            return new ActionResponse<IEnumerable<ExamenPeriodontal>>
            {
                WasSuccess = true,
                Result = examenes
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<ExamenPeriodontal>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<ExamenPeriodontal>> GetUltimoExamenAsync(Guid pacienteId)
    {
        try
        {
            var examen = await _context.ExamenesPeriodontales
                .Include(e => e.Medico).ThenInclude(m => m.Usuario)
                .Include(e => e.BolsasPeriodontales)
                .Where(e => e.PacienteId == pacienteId)
                .OrderByDescending(e => e.FechaExamen)
                .FirstOrDefaultAsync();

            if (examen == null)
            {
                return new ActionResponse<ExamenPeriodontal>
                {
                    WasSuccess = false,
                    Message = "No hay exámenes periodontales para este paciente"
                };
            }

            return new ActionResponse<ExamenPeriodontal>
            {
                WasSuccess = true,
                Result = examen
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<ExamenPeriodontal>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }
}