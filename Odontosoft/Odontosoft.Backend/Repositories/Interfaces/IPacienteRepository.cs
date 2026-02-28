using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;
using Odontosoft.Backend.Repositories.Interfaces;

public interface IPacienteRepository : IGenericRepository<Paciente>
{
    Task<ActionResponse<Paciente>> GetPacienteCompletoAsync(int pacienteId);

    Task<ActionResponse<IEnumerable<Paciente>>> BuscarPacientesAsync(int sucursalId, string termino);

    Task<ActionResponse<Paciente>> GetByNumeroExpedienteAsync(int sucursalId, string numeroExpediente);

    Task<ActionResponse<Paciente>> GetByCURPAsync(string curp);

    Task<ActionResponse<IEnumerable<Paciente>>> GetPacientesConAlergiasCriticasAsync(int sucursalId);

    Task<ActionResponse<string>> GenerarNumeroExpedienteAsync(int sucursalId);
}