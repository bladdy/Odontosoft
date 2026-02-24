using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class MedicoEspecialidad
    {
        public int Id { get; set; }
        public int MedicoId { get; set; }
        public int EspecialidadId { get; set; }

        [MaxLength(50)]
        public string CedulaEspecialidad { get; set; }

        public DateTime FechaObtencion { get; set; }

        // Relaciones
        public Medico Medico { get; set; }

        public Especialidad Especialidad { get; set; }
    }
}