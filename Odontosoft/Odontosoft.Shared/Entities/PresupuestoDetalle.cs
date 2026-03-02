using Odontosoft.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class PresupuestoDetalle : ITenantEntity
    {
        public int Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public int PresupuestoDentalId { get; set; }

        [Required, MaxLength(200)]
        public string Tratamiento { get; set; } = null!;

        [MaxLength(10)]
        public string? NumeroDiente { get; set; }

        [MaxLength(1000)]
        public string? Descripcion { get; set; }

        public int Cantidad { get; set; } = 1;

        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; } = 0;
        public decimal Total { get; set; }

        public int Prioridad { get; set; } = 1; // 1=Urgente, 2=Alta, 3=Media, 4=Baja

        [MaxLength(50)]
        public string? Estado { get; set; } // Pendiente, Realizado, Cancelado

        public DateTime? FechaEstimada { get; set; }
        public DateTime? FechaRealizada { get; set; }

        // Relaciones
        public PresupuestoDental PresupuestoDental { get; set; }
    }
}