using Odontosoft.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class BolsaPeriodontal : ITenantEntity
    {
        public int Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public int ExamenPeriodontalId { get; set; }

        [Required, MaxLength(10)]
        public string NumeroDiente { get; set; } = null!;

        // Mediciones en mm (6 puntos por diente)
        public int? VestibularMesial { get; set; }

        public int? VestibularCentral { get; set; }
        public int? VestibularDistal { get; set; }
        public int? LingualMesial { get; set; }
        public int? LingualCentral { get; set; }
        public int? LingualDistal { get; set; }

        public bool Sangrado { get; set; }
        public bool Supuracion { get; set; }

        [MaxLength(20)]
        public string? Movilidad { get; set; } // Grado 0, I, II, III

        [MaxLength(500)]
        public string? Observaciones { get; set; }

        // Relaciones
        public ExamenPeriodontal ExamenPeriodontal { get; set; }
    }
}