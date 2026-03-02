using System.Reflection;

namespace Odontosoft.Shared.Entities
{
    public class ClinicaModulo
    {
        public Guid Id { get; set; }
        public Guid ClinicaId { get; set; }
        public Guid ModuloId { get; set; }
        public DateTime FechaActivacion { get; set; } = DateTime.UtcNow;
        public DateTime? FechaVencimiento { get; set; }
        public bool Activo { get; set; } = true;

        // Relaciones
        public Clinica Clinica { get; set; }

        public Modulo Modulo { get; set; }
    }
}