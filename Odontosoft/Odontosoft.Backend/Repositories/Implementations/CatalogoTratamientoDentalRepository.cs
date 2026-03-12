using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using Odontosoft.Backend.Services;
using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

namespace Odontosoft.Backend.Repositories.Implementations;

public class CatalogoTratamientoDentalRepository
    : GenericRepository<CatalogoTratamientoDental>, ICatalogoTratamientoDentalRepository
{
    private readonly DataContext _context;

    public CatalogoTratamientoDentalRepository(
        DataContext context,
        ITenantService tenantService)
        : base(context, tenantService)
    {
        _context = context;
    }

    public async Task<ActionResponse<IEnumerable<CatalogoTratamientoDental>>> GetPorCategoriaAsync(string categoria)
    {
        try
        {
            var tratamientos = await _context.CatalogoTratamientosDentales
                .Where(t => t.Categoria == categoria && t.Activo)
                .OrderBy(t => t.Nombre)
                .ToListAsync();

            return new ActionResponse<IEnumerable<CatalogoTratamientoDental>>
            {
                WasSuccess = true,
                Result = tratamientos
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<CatalogoTratamientoDental>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<IEnumerable<string>>> GetCategoriasAsync()
    {
        try
        {
            var categorias = await _context.CatalogoTratamientosDentales
                .Where(t => t.Activo && !string.IsNullOrEmpty(t.Categoria))
                .Select(t => t.Categoria!)
                .Distinct()
                .OrderBy(c => c)
                .ToListAsync();

            return new ActionResponse<IEnumerable<string>>
            {
                WasSuccess = true,
                Result = categorias
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<string>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<CatalogoTratamientoDental>> GetByCodigoAsync(string codigo)
    {
        try
        {
            var tratamiento = await _context.CatalogoTratamientosDentales
                .FirstOrDefaultAsync(t => t.Codigo == codigo);

            if (tratamiento == null)
            {
                return new ActionResponse<CatalogoTratamientoDental>
                {
                    WasSuccess = false,
                    Message = "Tratamiento no encontrado"
                };
            }

            return new ActionResponse<CatalogoTratamientoDental>
            {
                WasSuccess = true,
                Result = tratamiento
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<CatalogoTratamientoDental>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }
}