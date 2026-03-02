using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;
using Odontosoft.Backend.Repositories.Interfaces;

public interface IRecetaRepository : IGenericRepository<Receta>
{
    Task<ActionResponse<Receta>> GetRecetaConDetallesAsync(Guid recetaId);

    Task<ActionResponse<IEnumerable<Receta>>> GetRecetasPacienteAsync(Guid pacienteId);

    Task<ActionResponse<IEnumerable<Receta>>> GetRecetasActivasAsync(Guid pacienteId);

    Task<ActionResponse<string>> GenerarNumeroRecetaAsync();
}