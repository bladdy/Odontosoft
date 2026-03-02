using Odontosoft.Shared.Interfaces;

namespace Odontosoft.Shared.Entities
{
    public class UsuarioRol : ITenantEntity
    {
        public Guid Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public Guid UsuarioSucursalId { get; set; }
        public Guid RolId { get; set; }
        public DateTime FechaAsignacion { get; set; } = DateTime.UtcNow;

        // Relaciones
        public UsuarioSucursal UsuarioSucursal { get; set; }

        public Rol Rol { get; set; }
    }
}