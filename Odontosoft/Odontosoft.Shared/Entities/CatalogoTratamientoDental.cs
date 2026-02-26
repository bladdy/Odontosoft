using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities
{
    public class CatalogoTratamientoDental
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Nombre { get; set; } = null!;

        [MaxLength(50)]
        public string? Codigo { get; set; }

        [MaxLength(100)]
        public string? Categoria { get; set; }

        // Preventiva, Operatoria, Endodoncia, Periodoncia, Cirugía, Ortodoncia, Prótesis, Estética

        [MaxLength(1000)]
        public string? Descripcion { get; set; }

        public decimal? PrecioBase { get; set; }

        public int? DuracionEstimadaMinutos { get; set; }

        public bool RequiereConsentimiento { get; set; }

        [MaxLength(500)]
        public string? MaterialesNecesarios { get; set; }

        public bool Activo { get; set; } = true;
    }
}