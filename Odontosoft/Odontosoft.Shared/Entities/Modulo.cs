using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class Modulo
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Nombre { get; set; }

        [Required, MaxLength(50)]
        public string Codigo { get; set; }

        [MaxLength(500)]
        public string Descripcion { get; set; }

        [MaxLength(50)]
        public string Icono { get; set; }

        public int Orden { get; set; }
        public bool Activo { get; set; } = true;

        [MaxLength(200)]
        public string Ruta { get; set; } // Ruta del módulo en el frontend

        public int? ModuloPadreId { get; set; } // Para submódulos

        // Relaciones
        public Modulo ModuloPadre { get; set; }

        public ICollection<Modulo> SubModulos { get; set; }
        public ICollection<ClinicaModulo> ClinicaModulos { get; set; }
        public ICollection<PermisoModulo> PermisosModulo { get; set; }
    }
}