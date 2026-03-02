using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

using Odontosoft.Backend.Repositories.Interfaces;
using System;

public interface IFacturaRepository : IGenericRepository<Factura>
{
    Task<ActionResponse<Factura>> GetFacturaConDetallesAsync(Guid facturaId);

    Task<ActionResponse<IEnumerable<Factura>>> GetFacturasPacienteAsync(Guid pacienteId);

    Task<ActionResponse<IEnumerable<Factura>>> GetFacturasPorEstadoAsync(Guid sucursalId, string estado);

    Task<ActionResponse<IEnumerable<Factura>>> GetFacturasPendientesPagoAsync(Guid sucursalId);

    Task<ActionResponse<string>> GenerarNumeroFacturaAsync(Guid sucursalId);

    Task<ActionResponse<decimal>> GetTotalFacturadoAsync(Guid sucursalId, DateTime fechaInicio, DateTime fechaFin);
}