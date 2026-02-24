using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class Receta
    {
        public int Id { get; set; }
        public int ConsultaId { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }

        [Required, MaxLength(30)]
        public string NumeroReceta { get; set; }

        [Required]
        public DateTime FechaEmision { get; set; }

        public DateTime? FechaVencimiento { get; set; }

        [MaxLength(2000)]
        public string Indicaciones { get; set; }

        [MaxLength(50)]
        public string Estado { get; set; } // Activa, Surtida, Vencida, Cancelada

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        // Relaciones
        public Consulta Consulta { get; set; }

        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
        public ICollection<RecetaDetalle> RecetaDetalles { get; set; }
    }
}