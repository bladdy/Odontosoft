using Odontosoft.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class Medico : ITenantEntity
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }

        public Guid TenantId { get; set; }

        [Required, MaxLength(50)]
        public string CedulaProfesional { get; set; }

        [MaxLength(100)]
        public string Universidad { get; set; }

        public int AnioTitulacion { get; set; }

        [MaxLength(2000)]
        public string Especialidades { get; set; } // JSON o texto separado por comas

        [MaxLength(500)]
        public string Firma { get; set; } // URL de la imagen de la firma

        [MaxLength(500)]
        public string Sello { get; set; } // URL de la imagen del sello

        public bool Activo { get; set; } = true;
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;

        // Relaciones EXISTENTES
        public Usuario Usuario { get; set; }

        public Tenant Tenant { get; set; } = null!;

        public ICollection<MedicoEspecialidad> MedicoEspecialidades { get; set; }
        public ICollection<HorarioMedico> HorariosMedico { get; set; }
        public ICollection<Cita> Citas { get; set; }
        public ICollection<Consulta> Consultas { get; set; }
    }
}