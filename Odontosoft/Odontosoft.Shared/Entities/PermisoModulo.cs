namespace Odontosoft.Shared.Entities
{
    public class PermisoModulo
    {
        public int Id { get; set; }
        public int UsuarioSucursalId { get; set; }
        public int ModuloId { get; set; }
        public bool PuedeLeer { get; set; } = false;
        public bool PuedeCrear { get; set; } = false;
        public bool PuedeEditar { get; set; } = false;
        public bool PuedeEliminar { get; set; } = false;
        public DateTime FechaAsignacion { get; set; } = DateTime.UtcNow;

        // Relaciones
        public UsuarioSucursal UsuarioSucursal { get; set; }

        public Modulo Modulo { get; set; }
    }
}