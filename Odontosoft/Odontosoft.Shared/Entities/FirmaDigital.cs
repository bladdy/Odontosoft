using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities
{
    public class FirmaDigital
    {
        public int Id { get; set; }
        public int ExpedienteClinicoId { get; set; }
        public ExpedienteClinico ExpedienteClinico { get; set; }

        public string FirmaBase64 { get; set; } // La firma codificada en base64
        public DateTime Fecha { get; set; }
    }
}