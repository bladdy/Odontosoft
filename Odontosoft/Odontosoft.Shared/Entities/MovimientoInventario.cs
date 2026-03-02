using Odontosoft.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class MovimientoInventario : ITenantEntity
    {
        public int Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public int ProductoId { get; set; }
        public int SucursalId { get; set; }

        [Required, MaxLength(50)]
        public string TipoMovimiento { get; set; } // Entrada, Salida, Ajuste, Devolución

        public int Cantidad { get; set; }

        public int StockAnterior { get; set; }
        public int StockNuevo { get; set; }

        [MaxLength(1000)]
        public string Motivo { get; set; }

        [MaxLength(100)]
        public string Referencia { get; set; }

        public DateTime FechaMovimiento { get; set; } = DateTime.UtcNow;
        public int UsuarioId { get; set; }

        // Relaciones
        public Producto Producto { get; set; }

        public Sucursal Sucursal { get; set; }
    }
}