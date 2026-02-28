using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

using Odontosoft.Backend.Repositories.Interfaces;

public interface IProductoRepository : IGenericRepository<Producto>
{
    Task<ActionResponse<IEnumerable<Producto>>> GetProductosPorSucursalAsync(int sucursalId);

    Task<ActionResponse<IEnumerable<Producto>>> GetProductosBajoStockAsync(int sucursalId);

    Task<ActionResponse<Producto>> GetByCodigoBarrasAsync(string codigoBarras);

    Task<ActionResponse<IEnumerable<Producto>>> GetProductosProximosVencerAsync(int sucursalId, int diasAnticipacion = 30);
}