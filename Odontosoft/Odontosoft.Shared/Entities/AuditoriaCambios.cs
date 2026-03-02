using Odontosoft.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities
{
    public class AuditoriaCambios : ITenantEntity
    {
        public Guid Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public Guid UsuarioId { get; set; }

        [Required, MaxLength(100)]
        public string Tabla { get; set; }

        [Required, MaxLength(50)]
        public string Operacion { get; set; } // INSERT, UPDATE, DELETE

        public int RegistroId { get; set; }

        public string ValoresAnteriores { get; set; } // JSON
        public string ValoresNuevos { get; set; } // JSON

        public DateTime FechaHora { get; set; } = DateTime.UtcNow;

        [MaxLength(100)]
        public string DireccionIP { get; set; }
    }
}