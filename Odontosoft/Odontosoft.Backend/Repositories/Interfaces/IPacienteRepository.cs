using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;
using Odontosoft.Backend.Repositories.Interfaces;
using Odontosoft.Shared.DTOs.Paciente;

public interface IPacienteRepository : IGenericRepository<Paciente>
{
    Task<ActionResponse<Paciente>> GetPacienteCompletoAsync(Guid pacienteId);

    Task<ActionResponse<IEnumerable<Paciente>>> BuscarPacientesAsync(Guid sucursalId, string termino);

    Task<ActionResponse<Paciente>> GetByNumeroExpedienteAsync(Guid sucursalId, string numeroExpediente);

    Task<ActionResponse<Paciente>> GetByCURPAsync(string curp);

    Task<ActionResponse<IEnumerable<Paciente>>> GetPacientesConAlergiasCriticasAsync(Guid sucursalId);

    Task<ActionResponse<string>> GenerarNumeroExpedienteAsync(Guid sucursalId);

    Task<ActionResponse<Paciente>> AddFullAsync(PacienteCreateDTO paciente);

    Task<ActionResponse<Paciente>> UpdateFullAsync(PacienteUpdateDTO paciente);

    Task<ActionResponse<bool>> InactivateAsync(Guid pacienteId);
}