using Odontosoft.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class Usuario : ITenantEntity
    {
        public int Id { get; set; }
        public Guid TenantId { get; set; }

        [Required, MaxLength(100)]
        public string NombreUsuario { get; set; }

        [Required, MaxLength(200)]
        public string Email { get; set; }

        [Required, MaxLength(500)]
        public string PasswordHash { get; set; }

        [Required, MaxLength(150)]
        public string Nombre { get; set; }

        [Required, MaxLength(150)]
        public string Apellidos { get; set; }

        [MaxLength(20)]
        public string Telefono { get; set; }

        [MaxLength(500)]
        public string Avatar { get; set; }

        public bool Activo { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime? FechaModificacion { get; set; }
        public DateTime? UltimoAcceso { get; set; }

        // Relaciones
        public Tenant Tenant { get; set; } = null!;

        public ICollection<UsuarioSucursal> UsuarioSucursales { get; set; }

        public ICollection<Medico> Medicos { get; set; } // Un usuario puede ser médico
    }
}