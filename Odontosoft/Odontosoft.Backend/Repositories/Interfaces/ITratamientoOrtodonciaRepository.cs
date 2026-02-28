using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

using Odontosoft.Backend.Repositories.Interfaces;

public interface ITratamientoOrtodonciaRepository : IGenericRepository<TratamientoOrtodoncia>
{
    Task<ActionResponse<TratamientoOrtodoncia>> GetTratamientoCompletoAsync(int tratamientoId);

    Task<ActionResponse<IEnumerable<TratamientoOrtodoncia>>> GetTratamientosActivosAsync(int medicoId);

    Task<ActionResponse<TratamientoOrtodoncia>> GetTratamientoActivoPacienteAsync(int pacienteId);

    Task<ActionResponse<string>> GenerarNumeroTratamientoAsync();
}