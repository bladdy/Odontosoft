using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities
{
    public class Diagnostico
    {
        public int Id { get; set; }
        public int ExpedienteClinicoId { get; set; }
        public ExpedienteClinico ExpedienteClinico { get; set; }

        public string DiagnosticoDescripcion { get; set; }
        public string CodigoICD { get; set; }
        public DateTime Fecha { get; set; }
    }
}