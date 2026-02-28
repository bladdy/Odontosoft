using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

using Odontosoft.Backend.Repositories.Interfaces;

public interface IFacturaRepository : IGenericRepository<Factura>
{
    Task<ActionResponse<Factura>> GetFacturaConDetallesAsync(int facturaId);

    Task<ActionResponse<IEnumerable<Factura>>> GetFacturasPacienteAsync(int pacienteId);

    Task<ActionResponse<IEnumerable<Factura>>> GetFacturasPorEstadoAsync(int sucursalId, string estado);

    Task<ActionResponse<IEnumerable<Factura>>> GetFacturasPendientesPagoAsync(int sucursalId);

    Task<ActionResponse<string>> GenerarNumeroFacturaAsync(int sucursalId);

    Task<ActionResponse<decimal>> GetTotalFacturadoAsync(int sucursalId, DateTime fechaInicio, DateTime fechaFin);
}