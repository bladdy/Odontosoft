using Odontosoft.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class DienteEstado : ITenantEntity
    {
        public Guid Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public Guid OdontogramaId { get; set; }

        [Required, MaxLength(10)]
        public string NumeroDiente { get; set; } = null!; // Ej: "11", "21", "55", etc. (Sistema FDI)

        [MaxLength(100)]
        public string? Estado { get; set; } // Sano, Cariado, Obturado, Ausente, Extraído, etc.

        // Superficies afectadas (para caries, obturaciones)
        public bool SuperficieOclusal { get; set; }

        public bool SuperficieMesial { get; set; }
        public bool SuperficieDistal { get; set; }
        public bool SuperficieVestibular { get; set; }
        public bool SuperficieLingual { get; set; }

        [MaxLength(1000)]
        public string? Diagnostico { get; set; }

        [MaxLength(1000)]
        public string? Observaciones { get; set; }

        [MaxLength(50)]
        public string? ColorNotacion { get; set; } // Para representación visual (rojo, azul, etc.)

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;

        // Relaciones
        public Odontograma Odontograma { get; set; }

        public ICollection<TratamientoDental> Tratamientos { get; set; }
    }
}