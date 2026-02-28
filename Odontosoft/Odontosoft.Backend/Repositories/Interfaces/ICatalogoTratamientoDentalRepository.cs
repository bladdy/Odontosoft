using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

using Odontosoft.Backend.Repositories.Interfaces;

public interface ICatalogoTratamientoDentalRepository : IGenericRepository<CatalogoTratamientoDental>
{
    Task<ActionResponse<IEnumerable<CatalogoTratamientoDental>>> GetPorCategoriaAsync(string categoria);

    Task<ActionResponse<IEnumerable<string>>> GetCategoriasAsync();

    Task<ActionResponse<CatalogoTratamientoDental>> GetByCodigoAsync(string codigo);
}