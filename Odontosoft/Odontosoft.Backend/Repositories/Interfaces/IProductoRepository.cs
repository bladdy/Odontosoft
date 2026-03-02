using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

using Odontosoft.Backend.Repositories.Interfaces;

public interface IProductoRepository : IGenericRepository<Producto>
{
    Task<ActionResponse<IEnumerable<Producto>>> GetProductosPorSucursalAsync(Guid sucursalId);

    Task<ActionResponse<IEnumerable<Producto>>> GetProductosBajoStockAsync(Guid sucursalId);

    Task<ActionResponse<Producto>> GetByCodigoBarrasAsync(string codigoBarras);

    Task<ActionResponse<IEnumerable<Producto>>> GetProductosProximosVencerAsync(Guid sucursalId, int diasAnticipacion = 30);
}