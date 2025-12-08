using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities
{
    public class ExpedienteClinico
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public int SucursalId { get; set; }
        public Sucursal Sucursal { get; set; }

        public ICollection<NotaClinica> NotasClinicas { get; set; }
        public ICollection<Diagnostico> Diagnosticos { get; set; }
        public ICollection<Tratamiento> Tratamientos { get; set; }
        public ICollection<Radiografia> Radiografias { get; set; }
        public ICollection<FotografiaIntraoral> FotografiasIntraorales { get; set; }
        public ICollection<Evolucion> Evoluciones { get; set; }
        public ICollection<Prescripcion> Prescripciones { get; set; }
        public ICollection<FirmaDigital> FirmasDigitales { get; set; }
    }
}