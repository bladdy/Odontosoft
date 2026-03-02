using Odontosoft.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class Consultorio : ITenantEntity
    {
        public int Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public int SucursalId { get; set; }

        [Required, MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(20)]
        public string Numero { get; set; }

        [MaxLength(500)]
        public string Descripcion { get; set; }

        public bool Activo { get; set; } = true;

        // Relaciones
        public Sucursal Sucursal { get; set; }

        public ICollection<Cita> Citas { get; set; }
    }
}