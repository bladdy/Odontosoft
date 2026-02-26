using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities
{
    public class TratamientoOrtodoncia
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }

        [Required, MaxLength(30)]
        public string NumeroTratamiento { get; set; } = null!;

        [Required]
        public DateTime FechaInicio { get; set; }

        public DateTime? FechaEstimadaFin { get; set; }
        public DateTime? FechaRealFin { get; set; }

        [MaxLength(100)]
        public string TipoAparato { get; set; } = null!; // Brackets metálicos, cerámicos, Invisalign, etc.

        [MaxLength(2000)]
        public string? DiagnosticoInicial { get; set; }

        [MaxLength(2000)]
        public string? ObjetivosTratamiento { get; set; }

        public int DuracionEstimadaMeses { get; set; }

        public decimal CostoTotal { get; set; }

        [MaxLength(50)]
        public string Estado { get; set; } = "Activo"; // Activo, Completado, Suspendido, Cancelado

        [MaxLength(2000)]
        public string? Observaciones { get; set; }

        // Relaciones
        public Paciente Paciente { get; set; }

        public Medico Medico { get; set; }
        public ICollection<ControlOrtodoncia> Controles { get; set; }
    }
}