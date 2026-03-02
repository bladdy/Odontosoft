using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

using Odontosoft.Backend.Repositories.Interfaces;

public interface IExamenPeriodontalRepository : IGenericRepository<ExamenPeriodontal>
{
    Task<ActionResponse<ExamenPeriodontal>> GetExamenCompletoAsync(Guid examenId);

    Task<ActionResponse<IEnumerable<ExamenPeriodontal>>> GetExamenesPacienteAsync(Guid pacienteId);

    Task<ActionResponse<ExamenPeriodontal>> GetUltimoExamenAsync(Guid pacienteId);
}