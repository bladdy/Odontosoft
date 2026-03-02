using Odontosoft.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class Antecedente : ITenantEntity
    {
        public int Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public int PacienteId { get; set; }

        [Required, MaxLength(50)]
        public string Tipo { get; set; } // Patológico, No Patológico, Quirúrgico, Familiar, Gineco-Obstétrico

        [Required, MaxLength(500)]
        public string Descripcion { get; set; }

        public DateTime? Fecha { get; set; }

        [MaxLength(2000)]
        public string Observaciones { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool Activo { get; set; } = true;

        // Relaciones
        public Paciente Paciente { get; set; }
    }
}