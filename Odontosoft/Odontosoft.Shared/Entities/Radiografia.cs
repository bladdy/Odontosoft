using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities
{
    public class Radiografia
    {
        public int Id { get; set; }
        public int ExpedienteClinicoId { get; set; }
        public ExpedienteClinico ExpedienteClinico { get; set; }

        public string Tipo { get; set; } // Ej. Panorámica, Periapical
        public string UrlArchivo { get; set; } // Ruta del archivo en el servidor o cloud
        public DateTime Fecha { get; set; }
    }
}