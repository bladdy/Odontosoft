using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;
using Odontosoft.Backend.Repositories.Interfaces;

public interface IMedicoRepository : IGenericRepository<Medico>
{
    Task<ActionResponse<Medico>> GetMedicoConEspecialidadesAsync(Guid medicoId);

    Task<ActionResponse<Medico>> GetMedicoConHorariosAsync(Guid medicoId, Guid sucursalId);

    Task<ActionResponse<IEnumerable<Medico>>> GetMedicosPorSucursalAsync(Guid sucursalId);

    Task<ActionResponse<IEnumerable<Medico>>> GetMedicosPorEspecialidadAsync(Guid especialidadId);

    Task<ActionResponse<Medico>> GetByCedulaAsync(string cedula);
}