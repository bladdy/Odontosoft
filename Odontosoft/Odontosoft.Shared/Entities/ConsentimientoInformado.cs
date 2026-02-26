using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities
{
    public class ConsentimientoInformado
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public int? TratamientoDentalId { get; set; }

        [Required, MaxLength(200)]
        public string TipoProcedimiento { get; set; } = null!;

        [Required]
        public DateTime FechaConsentimiento { get; set; }

        [Required]
        public string ContenidoConsentimiento { get; set; } = null!; // Texto completo del consentimiento

        public bool Aceptado { get; set; }

        [MaxLength(500)]
        public string? FirmaDigitalPaciente { get; set; } // Ruta o base64

        [MaxLength(500)]
        public string? FirmaDigitalMedico { get; set; }

        [MaxLength(500)]
        public string? FirmaDigitalTestigo { get; set; }

        [MaxLength(200)]
        public string? NombreTestigo { get; set; }

        [MaxLength(50)]
        public string? DireccionIP { get; set; }

        [MaxLength(2000)]
        public string? Observaciones { get; set; }

        // Relaciones
        public Paciente Paciente { get; set; }

        public Medico Medico { get; set; }
        public TratamientoDental? TratamientoDental { get; set; }
    }
}