using Odontosoft.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities
{
    public class Notificacion : ITenantEntity
    {
        public Guid Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public Guid UsuarioId { get; set; }

        [Required, MaxLength(200)]
        public string Titulo { get; set; }

        [Required, MaxLength(1000)]
        public string Mensaje { get; set; }

        [MaxLength(50)]
        public string Tipo { get; set; } // Info, Advertencia, Error, Éxito

        public bool Leida { get; set; } = false;

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime? FechaLectura { get; set; }

        [MaxLength(500)]
        public string Enlace { get; set; }
    }
}