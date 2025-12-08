using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities
{
    public class Clinica
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string RazonSocial { get; set; } // Razón social de la clínica
        public string RFC { get; set; } // RFC de la clínica
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }

        // Relación con las sucursales
        public ICollection<Sucursal> Sucursales { get; set; }
    }
}