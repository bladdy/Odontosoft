using Odontosoft.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class ControlOrtodoncia : ITenantEntity
    {
        public Guid Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public Guid TratamientoOrtodonciaId { get; set; }

        [Required]
        public DateTime FechaControl { get; set; }

        public int NumeroControl { get; set; }

        [MaxLength(2000)]
        public string? ActividadesRealizadas { get; set; } // Cambio de arco, activación, etc.

        [MaxLength(2000)]
        public string? EvolucionPaciente { get; set; }

        [MaxLength(2000)]
        public string? Observaciones { get; set; }

        public DateTime? FechaProximoControl { get; set; }

        [MaxLength(500)]
        public string? Fotografias { get; set; } // URLs

        // Relaciones
        public TratamientoOrtodoncia TratamientoOrtodoncia { get; set; }
    }
}