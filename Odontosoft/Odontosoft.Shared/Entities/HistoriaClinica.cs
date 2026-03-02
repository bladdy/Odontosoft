using Odontosoft.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class HistoriaClinica : ITenantEntity
    {
        public int Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public int PacienteId { get; set; }
        public int? ConsultaId { get; set; }

        [Required, MaxLength(50)]
        public string Tipo { get; set; } // Nota de Evolución, Nota de Ingreso, Nota de Egreso, etc.

        [Required]
        public string Contenido { get; set; } // Texto largo

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public int UsuarioRegistroId { get; set; }

        // Relaciones
        public Paciente Paciente { get; set; }

        public Consulta Consulta { get; set; }
    }
}