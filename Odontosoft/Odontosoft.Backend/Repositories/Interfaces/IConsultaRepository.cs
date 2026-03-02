using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;
using Odontosoft.Backend.Repositories.Interfaces;

public interface IConsultaRepository : IGenericRepository<Consulta>
{
    Task<ActionResponse<Consulta>> GetConsultaCompletaAsync(Guid consultaId);

    Task<ActionResponse<IEnumerable<Consulta>>> GetConsultasPacienteAsync(Guid pacienteId);

    Task<ActionResponse<IEnumerable<Consulta>>> GetConsultasMedicoAsync(Guid medicoId, DateTime? fechaInicio = null);

    Task<ActionResponse<string>> GenerarNumeroConsultaAsync();
}