using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities
{
    public class Sucursal
    {
        public int Id { get; set; }
        public int ClinicaId { get; set; }

        [Required, MaxLength(200)]
        public string Nombre { get; set; }

        [Required, MaxLength(20)]
        public string Codigo { get; set; }

        [MaxLength(20)]
        public string Telefono { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(500)]
        public string Direccion { get; set; }

        [MaxLength(100)]
        public string Ciudad { get; set; }

        [MaxLength(100)]
        public string Estado { get; set; }

        [MaxLength(10)]
        public string CodigoPostal { get; set; }

        public bool Activo { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime? FechaModificacion { get; set; }

        // Relaciones
        public Clinica Clinica { get; set; }

        public ICollection<UsuarioSucursal> UsuarioSucursales { get; set; }
        public ICollection<Consultorio> Consultorios { get; set; }
        public ICollection<Cita> Citas { get; set; }
        public ICollection<Paciente> Pacientes { get; set; }
    }
}