using Odontosoft.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities
{
    public class AuditoriaAcceso : ITenantEntity
    {
        public int Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public int UsuarioId { get; set; }
        public int SucursalId { get; set; }

        [Required, MaxLength(50)]
        public string TipoAcceso { get; set; } // Login, Logout, Cambio Sucursal

        [MaxLength(100)]
        public string DireccionIP { get; set; }

        [MaxLength(500)]
        public string UserAgent { get; set; }

        public DateTime FechaHora { get; set; } = DateTime.UtcNow;

        public bool Exitoso { get; set; } = true;

        [MaxLength(500)]
        public string MotivoFallo { get; set; }
    }
}