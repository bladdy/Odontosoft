using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

namespace Odontosoft.Backend.Repositories.Interfaces;

public interface IPresupuestoDentalRepository : IGenericRepository<PresupuestoDental>
{
    Task<ActionResponse<PresupuestoDental>> GetPresupuestoCompletoAsync(int presupuestoId);

    Task<ActionResponse<IEnumerable<PresupuestoDental>>> GetPresupuestosPacienteAsync(int pacienteId);

    Task<ActionResponse<IEnumerable<PresupuestoDental>>> GetPresupuestosPorEstadoAsync(int sucursalId, string estado);

    Task<ActionResponse<string>> GenerarNumeroPresupuestoAsync(int sucursalId);

    Task<ActionResponse<bool>> AprobarPresupuestoAsync(int presupuestoId);
}