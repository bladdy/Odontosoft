using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities
{
    public class FotografiaIntraoral
    {
        public int Id { get; set; }
        public int ExpedienteClinicoId { get; set; }
        public ExpedienteClinico ExpedienteClinico { get; set; }

        public string UrlArchivo { get; set; } // Ruta del archivo de la foto
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
    }
}