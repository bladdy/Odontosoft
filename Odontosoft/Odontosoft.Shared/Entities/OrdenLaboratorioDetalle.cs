using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class OrdenLaboratorioDetalle
    {
        public int Id { get; set; }
        public int OrdenLaboratorioId { get; set; }
        public int EstudioLaboratorioId { get; set; }

        [MaxLength(1000)]
        public string Resultado { get; set; }

        [MaxLength(200)]
        public string ValorReferencia { get; set; }

        [MaxLength(500)]
        public string Observaciones { get; set; }

        // Relaciones
        public OrdenLaboratorio OrdenLaboratorio { get; set; }

        public EstudioLaboratorio EstudioLaboratorio { get; set; }
    }
}