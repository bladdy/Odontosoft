using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;
using Odontosoft.Backend.Repositories.Interfaces;

public interface ICitaRepository : IGenericRepository<Cita>
{
    Task<ActionResponse<IEnumerable<Cita>>> GetAgendaMedicoAsync(Guid medicoId, DateTime fecha);

    Task<ActionResponse<IEnumerable<Cita>>> GetCitasPacienteAsync(Guid pacienteId, DateTime? fechaInicio = null);

    Task<ActionResponse<bool>> HorarioDisponibleAsync(Guid medicoId, DateTime fechaHora, int duracionMinutos);

    Task<ActionResponse<IEnumerable<Cita>>> GetCitasPorEstadoAsync(Guid sucursalId, string estado, DateTime? fecha = null);

    Task<ActionResponse<Cita>> GetCitaConDetallesAsync(Guid citaId);

    Task<ActionResponse<string>> GenerarNumeroCitaAsync(Guid sucursalId);
}