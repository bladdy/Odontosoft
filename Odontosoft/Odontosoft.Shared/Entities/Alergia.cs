using Odontosoft.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class Alergia : ITenantEntity
    {
        public Guid Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public Guid PacienteId { get; set; }

        [Required, MaxLength(200)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string Tipo { get; set; } // Medicamento, Alimento, Ambiental, Otro

        [MaxLength(50)]
        public string Gravedad { get; set; } // Leve, Moderada, Grave

        [MaxLength(1000)]
        public string Descripcion { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool Activo { get; set; } = true;

        // Relaciones
        public Paciente Paciente { get; set; }
    }
}