using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities
{
    public class Prescripcion
    {
        public int Id { get; set; }
        public int ExpedienteClinicoId { get; set; }
        public ExpedienteClinico ExpedienteClinico { get; set; }

        public string Medicamento { get; set; }
        public string Dosis { get; set; }
        public string Instrucciones { get; set; }
        public DateTime Fecha { get; set; }
    }
}