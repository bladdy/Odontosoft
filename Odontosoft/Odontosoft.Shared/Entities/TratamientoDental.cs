using Odontosoft.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class TratamientoDental : ITenantEntity
    {
        public Guid Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public Guid PacienteId { get; set; }
        public Guid MedicoId { get; set; }
        public Guid? ConsultaId { get; set; }
        public Guid? DienteEstadoId { get; set; }

        [Required, MaxLength(30)]
        public string NumeroTratamiento { get; set; } = null!;

        [Required]
        public DateTime FechaTratamiento { get; set; }

        [Required, MaxLength(200)]
        public string TipoTratamiento { get; set; } = null!; // Ej: Endodoncia, Extracción, Implante

        [MaxLength(10)]
        public string? NumeroDiente { get; set; } // Puede ser null si es tratamiento general

        [MaxLength(2000)]
        public string? Descripcion { get; set; }

        [MaxLength(50)]
        public string Estado { get; set; } = "Programado"; // Programado, EnProceso, Completado, Cancelado

        public int NumeroSesiones { get; set; } = 1;
        public int SesionActual { get; set; } = 1;

        public decimal? Costo { get; set; }

        [MaxLength(500)]
        public string? MaterialesUtilizados { get; set; }

        [MaxLength(2000)]
        public string? Observaciones { get; set; }

        public DateTime? FechaProximaCita { get; set; }

        public bool RequiereSeguimiento { get; set; }

        // Relaciones
        public Paciente Paciente { get; set; }

        public Medico Medico { get; set; }
        public Consulta? Consulta { get; set; }
        public DienteEstado? DienteEstado { get; set; }
        public ICollection<SeguimientoTratamiento> Seguimientos { get; set; }
    }
}