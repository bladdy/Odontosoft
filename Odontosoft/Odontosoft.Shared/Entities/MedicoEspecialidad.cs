using Odontosoft.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class MedicoEspecialidad : ITenantEntity
    {
        public Guid Id { get; set; }

        public Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public Guid MedicoId { get; set; }
        public Guid EspecialidadId { get; set; }

        [MaxLength(50)]
        public string CedulaEspecialidad { get; set; }

        public DateTime FechaObtencion { get; set; }

        // Relaciones
        public Medico Medico { get; set; }

        public Especialidad Especialidad { get; set; }
    }
}