using Odontosoft.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities
{
    public class MaterialDental : ITenantEntity
    {
        public Guid Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }

        [Required, MaxLength(200)]
        public string Nombre { get; set; } = null!;

        [MaxLength(50)]
        public string? Codigo { get; set; }

        [MaxLength(100)]
        public string? Categoria { get; set; }

        // Resinas, Cementos, Amalgamas, Anestésicos, Materiales de impresión, etc.

        [MaxLength(100)]
        public string? Marca { get; set; }

        [MaxLength(1000)]
        public string? Descripcion { get; set; }

        [MaxLength(100)]
        public string? UnidadMedida { get; set; } // Unidad, Caja, Frasco, Gramos, ml

        public decimal? PrecioUnitario { get; set; }

        public int? StockMinimo { get; set; }

        public DateTime? FechaCaducidad { get; set; }

        [MaxLength(50)]
        public string? Lote { get; set; }

        public bool Activo { get; set; } = true;
    }
}