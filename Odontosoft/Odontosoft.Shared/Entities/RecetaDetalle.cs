using Odontosoft.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class RecetaDetalle : ITenantEntity
    {
        public Guid Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public Guid RecetaId { get; set; }
        public Guid? MedicamentoId { get; set; }

        [Required, MaxLength(300)]
        public string MedicamentoNombre { get; set; }

        [MaxLength(200)]
        public string Presentacion { get; set; }

        [Required, MaxLength(1000)]
        public string Dosis { get; set; }

        [Required, MaxLength(1000)]
        public string Frecuencia { get; set; }

        [Required, MaxLength(1000)]
        public string Duracion { get; set; }

        [MaxLength(200)]
        public string Via { get; set; } // Oral, Tópica, Intravenosa, etc.

        [MaxLength(1000)]
        public string Indicaciones { get; set; }

        public int Cantidad { get; set; }

        // Relaciones
        public Receta Receta { get; set; }

        public Medicamento? Medicamento { get; set; }
    }
}