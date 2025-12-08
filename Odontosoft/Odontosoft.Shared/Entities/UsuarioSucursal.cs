using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities
{
    public class UsuarioSucursal
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int SucursalId { get; set; }
        public Sucursal Sucursal { get; set; }
    }
}