using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class OrdenImagenDetalle
    {
        public int Id { get; set; }
        public int OrdenImagenId { get; set; }
        public int EstudioImagenId { get; set; }

        [MaxLength(2000)]
        public string Resultado { get; set; }

        [MaxLength(500)]
        public string Observaciones { get; set; }

        // Relaciones
        public OrdenImagen OrdenImagen { get; set; }

        public EstudioImagen EstudioImagen { get; set; }
    }
}