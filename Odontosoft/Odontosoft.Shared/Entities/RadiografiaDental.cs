using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities
{
    public class RadiografiaDental
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int? MedicoId { get; set; }

        [Required, MaxLength(30)]
        public string NumeroRadiografia { get; set; } = null!;

        [Required]
        public DateTime FechaToma { get; set; }

        [Required, MaxLength(100)]
        public string TipoRadiografia { get; set; } = null!;

        // Periapical, Bite-Wing, Panorámica, Cefalométrica, Cone Beam (CBCT)

        [MaxLength(10)]
        public string? NumeroDiente { get; set; } // Si aplica a un diente específico

        [MaxLength(100)]
        public string? ZonaAnatomica { get; set; } // Superior, Inferior, Anterior, Posterior

        [Required, MaxLength(500)]
        public string RutaArchivo { get; set; } = null!;

        [MaxLength(1000)]
        public string? Hallazgos { get; set; }

        [MaxLength(2000)]
        public string? Observaciones { get; set; }

        [MaxLength(100)]
        public string? CalidadImagen { get; set; } // Excelente, Buena, Regular, Mala

        public bool RequiereAnalisis { get; set; }

        // Relaciones
        public Paciente Paciente { get; set; }

        public Medico? Medico { get; set; }
    }
}