using Odontosoft.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities;

public class FacturaDetalle : ITenantEntity
{
    public Guid Id { get; set; }

    public Tenant Tenant { get; set; }
    public Guid TenantId { get; set; }
    public Guid FacturaId { get; set; }
    public Guid? ServicioId { get; set; }

    [Required, MaxLength(500)]
    public string Concepto { get; set; }

    [MaxLength(100)]
    public string ClaveProdServ { get; set; } // Clave del SAT

    [MaxLength(100)]
    public string ClaveUnidad { get; set; } // Clave de unidad del SAT

    public decimal Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Subtotal { get; set; }
    public decimal IVA { get; set; }
    public decimal Total { get; set; }
    public decimal Descuento { get; set; } = 0;

    // Relaciones
    public Factura Factura { get; set; }

    public Servicio Servicio { get; set; }
}