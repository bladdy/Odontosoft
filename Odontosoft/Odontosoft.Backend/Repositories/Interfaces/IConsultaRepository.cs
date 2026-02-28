using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;
using Odontosoft.Backend.Repositories.Interfaces;

public interface IConsultaRepository : IGenericRepository<Consulta>
{
    Task<ActionResponse<Consulta>> GetConsultaCompletaAsync(int consultaId);

    Task<ActionResponse<IEnumerable<Consulta>>> GetConsultasPacienteAsync(int pacienteId);

    Task<ActionResponse<IEnumerable<Consulta>>> GetConsultasMedicoAsync(int medicoId, DateTime? fechaInicio = null);

    Task<ActionResponse<string>> GenerarNumeroConsultaAsync();
}