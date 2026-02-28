using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;
using Odontosoft.Backend.Repositories.Interfaces;

public interface ICitaRepository : IGenericRepository<Cita>
{
    Task<ActionResponse<IEnumerable<Cita>>> GetAgendaMedicoAsync(int medicoId, DateTime fecha);

    Task<ActionResponse<IEnumerable<Cita>>> GetCitasPacienteAsync(int pacienteId, DateTime? fechaInicio = null);

    Task<ActionResponse<bool>> HorarioDisponibleAsync(int medicoId, DateTime fechaHora, int duracionMinutos);

    Task<ActionResponse<IEnumerable<Cita>>> GetCitasPorEstadoAsync(int sucursalId, string estado, DateTime? fecha = null);

    Task<ActionResponse<Cita>> GetCitaConDetallesAsync(int citaId);

    Task<ActionResponse<string>> GenerarNumeroCitaAsync(int sucursalId);
}