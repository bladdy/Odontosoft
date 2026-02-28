using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

namespace Odontosoft.Backend.Repositories.Interfaces;

public interface ITratamientoDentalRepository : IGenericRepository<TratamientoDental>
{
    Task<ActionResponse<TratamientoDental>> GetTratamientoCompletoAsync(int tratamientoId);

    Task<ActionResponse<IEnumerable<TratamientoDental>>> GetTratamientosPacienteAsync(int pacienteId);

    Task<ActionResponse<IEnumerable<TratamientoDental>>> GetTratamientosActivosAsync(int medicoId);

    Task<ActionResponse<IEnumerable<TratamientoDental>>> GetTratamientosPorEstadoAsync(int sucursalId, string estado);

    Task<ActionResponse<string>> GenerarNumeroTratamientoAsync();
}