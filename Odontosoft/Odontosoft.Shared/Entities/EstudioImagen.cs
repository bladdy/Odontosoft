using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class EstudioImagen
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Nombre { get; set; }

        [MaxLength(100)]
        public string Codigo { get; set; }

        [MaxLength(100)]
        public string Tipo { get; set; } // Rayos X, Tomografía, Resonancia, Ultrasonido, etc.

        [MaxLength(1000)]
        public string Descripcion { get; set; }

        [MaxLength(500)]
        public string Preparacion { get; set; }

        public decimal? Precio { get; set; }
        public bool Activo { get; set; } = true;

        // Relaciones
        public ICollection<OrdenImagenDetalle> OrdenImagenDetalles { get; set; }
    }
}