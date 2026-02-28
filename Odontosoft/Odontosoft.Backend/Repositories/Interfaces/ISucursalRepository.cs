using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;
using Odontosoft.Backend.Repositories.Interfaces;

public interface ISucursalRepository : IGenericRepository<Sucursal>
{
    Task<ActionResponse<IEnumerable<Sucursal>>> GetSucursalesPorClinicaAsync(int clinicaId);

    Task<ActionResponse<Sucursal>> GetSucursalConConsultoriosAsync(int sucursalId);

    Task<ActionResponse<Sucursal>> GetByCodigoAsync(int clinicaId, string codigo);
}