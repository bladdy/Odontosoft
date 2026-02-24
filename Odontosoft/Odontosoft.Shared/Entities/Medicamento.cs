using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class Medicamento
    {
        public int Id { get; set; }

        [Required, MaxLength(300)]
        public string Nombre { get; set; }

        [MaxLength(300)]
        public string NombreGenerico { get; set; }

        [MaxLength(200)]
        public string Presentacion { get; set; }

        [MaxLength(100)]
        public string Concentracion { get; set; }

        [MaxLength(100)]
        public string Via { get; set; }

        [MaxLength(100)]
        public string Laboratorio { get; set; }

        [MaxLength(1000)]
        public string Descripcion { get; set; }

        public bool RequiereReceta { get; set; } = false;
        public bool Activo { get; set; } = true;

        // Relaciones
        public ICollection<RecetaDetalle> RecetaDetalles { get; set; }
    }
}