using Odontosoft.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class Pago : ITenantEntity
    {
        public int Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public int FacturaId { get; set; }

        [Required, MaxLength(30)]
        public string NumeroPago { get; set; }

        [Required]
        public DateTime FechaPago { get; set; }

        [Required, MaxLength(50)]
        public string FormaPago { get; set; } // Efectivo, Tarjeta, Transferencia

        public decimal Monto { get; set; }

        [MaxLength(100)]
        public string Referencia { get; set; }

        [MaxLength(1000)]
        public string Observaciones { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        // Relaciones
        public Factura Factura { get; set; }
    }
}