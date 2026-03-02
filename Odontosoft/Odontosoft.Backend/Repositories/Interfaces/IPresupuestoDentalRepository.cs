using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

namespace Odontosoft.Backend.Repositories.Interfaces;

public interface IPresupuestoDentalRepository : IGenericRepository<PresupuestoDental>
{
    Task<ActionResponse<PresupuestoDental>> GetPresupuestoCompletoAsync(Guid presupuestoId);

    Task<ActionResponse<IEnumerable<PresupuestoDental>>> GetPresupuestosPacienteAsync(Guid pacienteId);

    Task<ActionResponse<IEnumerable<PresupuestoDental>>> GetPresupuestosPorEstadoAsync(Guid sucursalId, string estado);

    Task<ActionResponse<string>> GenerarNumeroPresupuestoAsync(Guid sucursalId);

    Task<ActionResponse<bool>> AprobarPresupuestoAsync(Guid presupuestoId);
}