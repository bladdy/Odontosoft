using Odontosoft.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class Consulta : ITenantEntity
    {
        public Guid Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public Guid CitaId { get; set; }
        public Guid MedicoId { get; set; }
        public Guid PacienteId { get; set; }

        [Required, MaxLength(30)]
        public string NumeroConsulta { get; set; }

        [Required]
        public DateTime FechaConsulta { get; set; }

        // Signos Vitales
        public decimal? Peso { get; set; }

        public decimal? Altura { get; set; }
        public decimal? IMC { get; set; }
        public decimal? Temperatura { get; set; }
        public string PresionArterial { get; set; }
        public int? FrecuenciaCardiaca { get; set; }
        public int? FrecuenciaRespiratoria { get; set; }
        public int? SaturacionO2 { get; set; }

        [MaxLength(2000)]
        public string MotivoConsulta { get; set; }

        [MaxLength(5000)]
        public string PadecimientoActual { get; set; }

        [MaxLength(2000)]
        public string ExploracionFisica { get; set; }

        [MaxLength(1000)]
        public string Diagnostico { get; set; }

        [MaxLength(50)]
        public string CodigoCIE10 { get; set; }

        [MaxLength(2000)]
        public string PlanTratamiento { get; set; }

        [MaxLength(2000)]
        public string Observaciones { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime? FechaModificacion { get; set; }

        // Relaciones
        public Cita Cita { get; set; }

        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
        public ICollection<Receta> Recetas { get; set; }
        public ICollection<OrdenLaboratorio> OrdenesLaboratorio { get; set; }
        public ICollection<OrdenImagen> OrdenesImagen { get; set; }
    }
}