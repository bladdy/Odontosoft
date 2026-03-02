using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;
using Odontosoft.Backend.Repositories.Interfaces;

public interface ISucursalRepository : IGenericRepository<Sucursal>
{
    Task<ActionResponse<IEnumerable<Sucursal>>> GetSucursalesPorClinicaAsync(Guid clinicaId);

    Task<ActionResponse<Sucursal>> GetSucursalConConsultoriosAsync(Guid sucursalId);

    Task<ActionResponse<Sucursal>> GetByCodigoAsync(Guid clinicaId, string codigo);
}