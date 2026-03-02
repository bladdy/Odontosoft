using Odontosoft.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class Servicio : ITenantEntity
    {
        public int Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }

        [Required, MaxLength(200)]
        public string Nombre { get; set; }

        [MaxLength(100)]
        public string Codigo { get; set; }

        [MaxLength(100)]
        public string ClaveProdServ { get; set; }

        [MaxLength(1000)]
        public string Descripcion { get; set; }

        public decimal Precio { get; set; }
        public decimal IVA { get; set; } = 16; // Porcentaje

        [MaxLength(100)]
        public string Categoria { get; set; }

        public bool Activo { get; set; } = true;

        // Relaciones
        public ICollection<FacturaDetalle> FacturaDetalles { get; set; }
    }
}