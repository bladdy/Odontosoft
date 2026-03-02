using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

namespace Odontosoft.Backend.Repositories.Interfaces;

public interface ITratamientoDentalRepository : IGenericRepository<TratamientoDental>
{
    Task<ActionResponse<TratamientoDental>> GetTratamientoCompletoAsync(Guid tratamientoId);

    Task<ActionResponse<IEnumerable<TratamientoDental>>> GetTratamientosPacienteAsync(Guid pacienteId);

    Task<ActionResponse<IEnumerable<TratamientoDental>>> GetTratamientosActivosAsync(Guid medicoId);

    Task<ActionResponse<IEnumerable<TratamientoDental>>> GetTratamientosPorEstadoAsync(Guid sucursalId, string estado);

    Task<ActionResponse<string>> GenerarNumeroTratamientoAsync();
}