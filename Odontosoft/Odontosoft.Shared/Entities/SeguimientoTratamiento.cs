using Odontosoft.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class SeguimientoTratamiento : ITenantEntity
    {
        public Guid Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public Guid TratamientoDentalId { get; set; }

        public int NumeroSesion { get; set; }

        [Required]
        public DateTime FechaSesion { get; set; }

        [MaxLength(2000)]
        public string? Descripcion { get; set; }

        [MaxLength(2000)]
        public string? Observaciones { get; set; }

        [MaxLength(50)]
        public string? EstadoPaciente { get; set; } // Mejoría, Estable, Complicación

        public Guid? MedicoId { get; set; }

        [MaxLength(500)]
        public string? Imagenes { get; set; } // URLs separadas por coma

        // Relaciones
        public TratamientoDental TratamientoDental { get; set; }

        public Medico? Medico { get; set; }
    }
}