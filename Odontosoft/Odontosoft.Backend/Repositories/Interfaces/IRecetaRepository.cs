using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;
using Odontosoft.Backend.Repositories.Interfaces;

public interface IRecetaRepository : IGenericRepository<Receta>
{
    Task<ActionResponse<Receta>> GetRecetaConDetallesAsync(int recetaId);

    Task<ActionResponse<IEnumerable<Receta>>> GetRecetasPacienteAsync(int pacienteId);

    Task<ActionResponse<IEnumerable<Receta>>> GetRecetasActivasAsync(int pacienteId);

    Task<ActionResponse<string>> GenerarNumeroRecetaAsync();
}