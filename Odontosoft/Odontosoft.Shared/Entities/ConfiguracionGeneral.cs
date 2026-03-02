using Odontosoft.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities
{
    public class ConfiguracionGeneral : ITenantEntity
    {
        public Guid Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public Guid? ClinicaId { get; set; }
        public Guid? SucursalId { get; set; }

        [Required, MaxLength(100)]
        public string Clave { get; set; }

        [Required]
        public string Valor { get; set; }

        [MaxLength(500)]
        public string Descripcion { get; set; }

        [MaxLength(50)]
        public string Tipo { get; set; } // String, Number, Boolean, JSON

        public DateTime FechaModificacion { get; set; } = DateTime.UtcNow;
    }
}