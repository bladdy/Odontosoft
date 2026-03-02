using Odontosoft.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class Odontograma : ITenantEntity
    {
        public int Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        public DateTime? FechaActualizacion { get; set; }

        [MaxLength(50)]
        public string TipoOdontograma { get; set; } = "Permanente"; // Permanente, Temporal, Mixto

        [MaxLength(2000)]
        public string? Observaciones { get; set; }

        public bool EsActivo { get; set; } = true;

        // Relaciones
        public Paciente Paciente { get; set; }

        public Medico Medico { get; set; }
        public ICollection<DienteEstado> DientesEstado { get; set; }
    }
}