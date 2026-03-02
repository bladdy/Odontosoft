using Odontosoft.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class HorarioMedico : ITenantEntity
    {
        public int Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public int MedicoId { get; set; }
        public int SucursalId { get; set; }

        [Required, MaxLength(20)]
        public string DiaSemana { get; set; } // Lunes, Martes, etc.

        [Required]
        public TimeSpan HoraInicio { get; set; }

        [Required]
        public TimeSpan HoraFin { get; set; }

        public int DuracionCitaMinutos { get; set; } = 30;

        public bool Activo { get; set; } = true;

        // Relaciones
        public Medico Medico { get; set; }

        public Sucursal Sucursal { get; set; }
    }
}