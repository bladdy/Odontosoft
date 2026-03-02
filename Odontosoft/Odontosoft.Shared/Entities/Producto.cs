using Odontosoft.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities
{
    public class Producto : ITenantEntity
    {
        public int Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public int Id { get; set; }
        public int SucursalId { get; set; }

        [Required, MaxLength(200)]
        public string Nombre { get; set; }

        [MaxLength(100)]
        public string Codigo { get; set; }

        [MaxLength(100)]
        public string CodigoBarras { get; set; }

        [MaxLength(1000)]
        public string Descripcion { get; set; }

        [MaxLength(100)]
        public string Categoria { get; set; }

        [MaxLength(100)]
        public string Marca { get; set; }

        [MaxLength(100)]
        public string Presentacion { get; set; }

        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }

        public int StockMinimo { get; set; }
        public int StockMaximo { get; set; }
        public int StockActual { get; set; }

        public DateTime? FechaCaducidad { get; set; }

        [MaxLength(100)]
        public string Lote { get; set; }

        public bool Activo { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        // Relaciones
        public Sucursal Sucursal { get; set; }

        public ICollection<MovimientoInventario> MovimientosInventario { get; set; }
    }
}