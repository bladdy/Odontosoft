using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

using Odontosoft.Backend.Repositories.Interfaces;

public interface ITratamientoOrtodonciaRepository : IGenericRepository<TratamientoOrtodoncia>
{
    Task<ActionResponse<TratamientoOrtodoncia>> GetTratamientoCompletoAsync(Guid tratamientoId);

    Task<ActionResponse<IEnumerable<TratamientoOrtodoncia>>> GetTratamientosActivosAsync(Guid medicoId);

    Task<ActionResponse<TratamientoOrtodoncia>> GetTratamientoActivoPacienteAsync(Guid pacienteId);

    Task<ActionResponse<string>> GenerarNumeroTratamientoAsync();
}