using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

namespace Odontosoft.Backend.Repositories.Implementations;

public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
{
    private readonly DataContext _context;

    public ProductoRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ActionResponse<IEnumerable<Producto>>> GetProductosPorSucursalAsync(int sucursalId)
    {
        try
        {
            var productos = await _context.Productos
                .Include(p => p.Sucursal)
                .Where(p => p.SucursalId == sucursalId && p.Activo)
                .OrderBy(p => p.Nombre)
                .ToListAsync();

            return new ActionResponse<IEnumerable<Producto>>
            {
                WasSuccess = true,
                Result = productos
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<Producto>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<IEnumerable<Producto>>> GetProductosBajoStockAsync(int sucursalId)
    {
        try
        {
            var productos = await _context.Productos
                .Where(p => p.SucursalId == sucursalId &&
                           p.Activo &&
                           p.StockActual <= p.StockMinimo)
                .OrderBy(p => p.StockActual)
                .ToListAsync();

            return new ActionResponse<IEnumerable<Producto>>
            {
                WasSuccess = true,
                Result = productos
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<Producto>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<Producto>> GetByCodigoBarrasAsync(string codigoBarras)
    {
        try
        {
            var producto = await _context.Productos
                .Include(p => p.Sucursal)
                .FirstOrDefaultAsync(p => p.CodigoBarras == codigoBarras);

            if (producto == null)
            {
                return new ActionResponse<Producto>
                {
                    WasSuccess = false,
                    Message = "Producto no encontrado"
                };
            }

            return new ActionResponse<Producto>
            {
                WasSuccess = true,
                Result = producto
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<Producto>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<IEnumerable<Producto>>> GetProductosProximosVencerAsync(int sucursalId, int diasAnticipacion = 30)
    {
        try
        {
            var fechaLimite = DateTime.UtcNow.AddDays(diasAnticipacion);

            var productos = await _context.Productos
                .Where(p => p.SucursalId == sucursalId &&
                           p.Activo &&
                           p.FechaCaducidad.HasValue &&
                           p.FechaCaducidad.Value <= fechaLimite)
                .OrderBy(p => p.FechaCaducidad)
                .ToListAsync();

            return new ActionResponse<IEnumerable<Producto>>
            {
                WasSuccess = true,
                Result = productos
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<Producto>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }
}