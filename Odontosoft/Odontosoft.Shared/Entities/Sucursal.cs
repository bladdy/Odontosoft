using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities
{
    public class Sucursal
    {
        public int Id { get; set; }
        public int ClinicaId { get; set; }
        public Clinica Clinica { get; set; }

        public string Nombre { get; set; } // Nombre de la sucursal (ej. "Sucursal Norte")
        public string Direccion { get; set; } // Dirección de la sucursal
        public string Telefono { get; set; } // Teléfono de la sucursal
        public string Email { get; set; } // Correo electrónico de la sucursal
        public string Horarios { get; set; } // Horarios de atención

        // Relación con los usuarios de la sucursal
        public ICollection<UsuarioSucursal> UsuarioSucursales { get; set; }

        // Relación con los expedientes clínicos
        public ICollection<ExpedienteClinico> ExpedientesClinicos { get; set; }
    }
}