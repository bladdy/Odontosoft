using Odontosoft.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class OrdenImagenDetalle : ITenantEntity
    {
        public Guid Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public Guid OrdenImagenId { get; set; }
        public Guid EstudioImagenId { get; set; }

        [MaxLength(2000)]
        public string Resultado { get; set; }

        [MaxLength(500)]
        public string Observaciones { get; set; }

        // Relaciones
        public OrdenImagen OrdenImagen { get; set; }

        public EstudioImagen EstudioImagen { get; set; }
    }
}