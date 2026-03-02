using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

namespace Odontosoft.Backend.Repositories.Interfaces;

public interface IOdontogramaRepository : IGenericRepository<Odontograma>
{
    Task<ActionResponse<Odontograma>> GetOdontogramaActualAsync(Guid pacienteId);

    Task<ActionResponse<Odontograma>> GetOdontogramaCompletoAsync(Guid odontogramaId);

    Task<ActionResponse<IEnumerable<Odontograma>>> GetHistorialAsync(Guid pacienteId);

    Task<ActionResponse<Odontograma>> CrearOdontogramaInicialAsync(Guid pacienteId, Guid medicoId, string tipo);
}