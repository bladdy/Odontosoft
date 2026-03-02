using Odontosoft.Shared.Interfaces;

namespace Odontosoft.Shared.Entities
{
    public class PermisoModulo : ITenantEntity
    {
        public Guid Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public Guid UsuarioSucursalId { get; set; }
        public Guid ModuloId { get; set; }
        public bool PuedeLeer { get; set; } = false;
        public bool PuedeCrear { get; set; } = false;
        public bool PuedeEditar { get; set; } = false;
        public bool PuedeEliminar { get; set; } = false;
        public DateTime FechaAsignacion { get; set; } = DateTime.UtcNow;

        // Relaciones
        public UsuarioSucursal UsuarioSucursal { get; set; }

        public Modulo Modulo { get; set; }
    }
}