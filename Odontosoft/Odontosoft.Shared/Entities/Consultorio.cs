using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class Consultorio
    {
        public int Id { get; set; }
        public int SucursalId { get; set; }

        [Required, MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(20)]
        public string Numero { get; set; }

        [MaxLength(500)]
        public string Descripcion { get; set; }

        public bool Activo { get; set; } = true;

        // Relaciones
        public Sucursal Sucursal { get; set; }

        public ICollection<Cita> Citas { get; set; }
    }
}