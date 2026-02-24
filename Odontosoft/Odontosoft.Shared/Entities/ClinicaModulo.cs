using System.Reflection;

namespace Odontosoft.Shared.Entities
{
    public class ClinicaModulo
    {
        public int Id { get; set; }
        public int ClinicaId { get; set; }
        public int ModuloId { get; set; }
        public DateTime FechaActivacion { get; set; } = DateTime.UtcNow;
        public DateTime? FechaVencimiento { get; set; }
        public bool Activo { get; set; } = true;

        // Relaciones
        public Clinica Clinica { get; set; }

        public Modulo Modulo { get; set; }
    }
}