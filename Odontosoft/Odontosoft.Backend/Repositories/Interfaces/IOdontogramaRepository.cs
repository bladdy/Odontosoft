using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

namespace Odontosoft.Backend.Repositories.Interfaces;

public interface IOdontogramaRepository : IGenericRepository<Odontograma>
{
    Task<ActionResponse<Odontograma>> GetOdontogramaActualAsync(int pacienteId);

    Task<ActionResponse<Odontograma>> GetOdontogramaCompletoAsync(int odontogramaId);

    Task<ActionResponse<IEnumerable<Odontograma>>> GetHistorialAsync(int pacienteId);

    Task<ActionResponse<Odontograma>> CrearOdontogramaInicialAsync(int pacienteId, int medicoId, string tipo);
}