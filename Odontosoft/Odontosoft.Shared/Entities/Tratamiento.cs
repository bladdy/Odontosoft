using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities
{
    public class Tratamiento
    {
        public int Id { get; set; }
        public int ExpedienteClinicoId { get; set; }
        public ExpedienteClinico ExpedienteClinico { get; set; }

        public string Descripcion { get; set; }
        public string Fase { get; set; } // Fase del tratamiento (ej. fase 1, fase 2)
        public decimal Costo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}