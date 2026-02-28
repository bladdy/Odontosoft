using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;
using Odontosoft.Backend.Repositories.Interfaces;

public interface IMedicoRepository : IGenericRepository<Medico>
{
    Task<ActionResponse<Medico>> GetMedicoConEspecialidadesAsync(int medicoId);

    Task<ActionResponse<Medico>> GetMedicoConHorariosAsync(int medicoId, int sucursalId);

    Task<ActionResponse<IEnumerable<Medico>>> GetMedicosPorSucursalAsync(int sucursalId);

    Task<ActionResponse<IEnumerable<Medico>>> GetMedicosPorEspecialidadAsync(int especialidadId);

    Task<ActionResponse<Medico>> GetByCedulaAsync(string cedula);
}