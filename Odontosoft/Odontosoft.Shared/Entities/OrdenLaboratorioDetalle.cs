using Odontosoft.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class OrdenLaboratorioDetalle : ITenantEntity
    {
        public Guid Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public Guid OrdenLaboratorioId { get; set; }
        public Guid EstudioLaboratorioId { get; set; }

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