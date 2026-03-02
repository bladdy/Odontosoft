using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities
{
    public class UsuarioSucursal
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid SucursalId { get; set; }
        public bool EsSucursalPrincipal { get; set; } = false;
        public DateTime FechaAsignacion { get; set; } = DateTime.UtcNow;
        public bool Activo { get; set; } = true;

        // Relaciones
        public Usuario Usuario { get; set; }

        public Sucursal Sucursal { get; set; }
        public ICollection<PermisoModulo> PermisosModulo { get; set; }
    }
}