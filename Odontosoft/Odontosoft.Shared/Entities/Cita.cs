using Odontosoft.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class Cita : ITenantEntity
    {
        public int Id { get; set; }
        public Guid TenantId { get; set; }
        public int SucursalId { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public int? ConsultorioId { get; set; }

        [Required, MaxLength(30)]
        public string NumeroCita { get; set; }

        [Required]
        public DateTime FechaHora { get; set; }

        public int DuracionMinutos { get; set; } = 30;

        [Required, MaxLength(50)]
        public string EstadoCita { get; set; } // Programada, Confirmada, En Espera, En Consulta, Completada, Cancelada, No Asistió

        [Required, MaxLength(50)]
        public string TipoCita { get; set; } // Primera Vez, Seguimiento, Urgencia

        [MaxLength(1000)]
        public string MotivoConsulta { get; set; }

        [MaxLength(1000)]
        public string Observaciones { get; set; }

        [MaxLength(200)]
        public string ColorCalendario { get; set; }

        public DateTime? FechaConfirmacion { get; set; }
        public DateTime? FechaCancelacion { get; set; }

        [MaxLength(500)]
        public string MotivoCancelacion { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime? FechaModificacion { get; set; }

        // Relaciones
        public Sucursal Sucursal { get; set; }

        public Tenant Tenant { get; set; } = null!;
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
        public Consultorio Consultorio { get; set; }
        public Consulta Consulta { get; set; }
    }
}