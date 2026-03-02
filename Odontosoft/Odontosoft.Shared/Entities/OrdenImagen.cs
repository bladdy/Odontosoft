using Odontosoft.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class OrdenImagen : ITenantEntity
    {
        public int Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public int ConsultaId { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }

        [Required, MaxLength(30)]
        public string NumeroOrden { get; set; }

        [Required]
        public DateTime FechaEmision { get; set; }

        [MaxLength(50)]
        public string Estado { get; set; } // Pendiente, En Proceso, Completada, Cancelada

        [MaxLength(1000)]
        public string Indicaciones { get; set; }

        public DateTime? FechaResultado { get; set; }

        [MaxLength(500)]
        public string ArchivoResultado { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        // Relaciones
        public Consulta Consulta { get; set; }

        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
        public ICollection<OrdenImagenDetalle> OrdenImagenDetalles { get; set; }
    }
}