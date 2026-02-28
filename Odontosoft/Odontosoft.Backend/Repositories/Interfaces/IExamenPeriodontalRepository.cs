using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

using Odontosoft.Backend.Repositories.Interfaces;

public interface IExamenPeriodontalRepository : IGenericRepository<ExamenPeriodontal>
{
    Task<ActionResponse<ExamenPeriodontal>> GetExamenCompletoAsync(int examenId);

    Task<ActionResponse<IEnumerable<ExamenPeriodontal>>> GetExamenesPacienteAsync(int pacienteId);

    Task<ActionResponse<ExamenPeriodontal>> GetUltimoExamenAsync(int pacienteId);
}