using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Puede ser un hash de la contraseña
        public string Rol { get; set; } // Rol del usuario (administrador, odontólogo, recepcionista, etc.)

        // Relación con las sucursales
        public ICollection<UsuarioSucursal> UsuarioSucursales { get; set; }

        // Relación con los expedientes clínicos
        public ICollection<ExpedienteClinico> ExpedientesClinicos { get; set; }
    }
}