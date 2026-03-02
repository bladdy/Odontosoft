using Odontosoft.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class Factura : ITenantEntity
    {
        public Guid Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public Guid SucursalId { get; set; }
        public Guid PacienteId { get; set; }
        public Guid? CitaId { get; set; }

        [Required, MaxLength(50)]
        public string NumeroFactura { get; set; }

        [MaxLength(50)]
        public string Serie { get; set; }

        [MaxLength(50)]
        public string Folio { get; set; }

        [Required]
        public DateTime FechaEmision { get; set; }

        [MaxLength(50)]
        public string TipoComprobante { get; set; } // Ingreso, Egreso, Traslado, Pago

        [MaxLength(50)]
        public string MetodoPago { get; set; } // PUE (Pago en una exhibición), PPD (Pago en parcialidades)

        [MaxLength(50)]
        public string FormaPago { get; set; } // Efectivo, Tarjeta, Transferencia, etc.

        public decimal Subtotal { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public decimal Descuento { get; set; } = 0;

        [MaxLength(50)]
        public string Estado { get; set; } // Vigente, Cancelada, Pagada, Pendiente

        [MaxLength(100)]
        public string UUID { get; set; } // Folio fiscal del SAT

        [MaxLength(500)]
        public string ArchivoXML { get; set; }

        [MaxLength(500)]
        public string ArchivoPDF { get; set; }

        [MaxLength(1000)]
        public string Observaciones { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime? FechaCancelacion { get; set; }

        [MaxLength(500)]
        public string MotivoCancelacion { get; set; }

        // Relaciones
        public Sucursal Sucursal { get; set; }

        public Paciente Paciente { get; set; }
        public Cita Cita { get; set; }
        public ICollection<FacturaDetalle> FacturaDetalles { get; set; }
        public ICollection<Pago> Pagos { get; set; }
    }
}