using Odontosoft.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities
{
    public class Clinica : ITenantEntity
    {
        public int Id { get; set; }

        public Guid TenantId { get; set; }

        [Required, MaxLength(200)]
        public string Nombre { get; set; }

        [MaxLength(250)]
        public string RazonSocial { get; set; }

        [MaxLength(13)]
        public string RFC { get; set; }

        [MaxLength(20)]
        public string Telefono { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(500)]
        public string Direccion { get; set; }

        [MaxLength(100)]
        public string Ciudad { get; set; }

        [MaxLength(100)]
        public string Estado { get; set; }

        [MaxLength(10)]
        public string CodigoPostal { get; set; }

        [MaxLength(500)]
        public string Logo { get; set; } // URL del logo

        public bool Activo { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime? FechaModificacion { get; set; }

        // Relaciones
        public Tenant Tenant { get; set; } = null!;

        public ICollection<Sucursal> Sucursales { get; set; }

        public ICollection<ClinicaModulo> ClinicaModulos { get; set; }
    }
}