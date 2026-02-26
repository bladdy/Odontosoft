using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.Entities
{
    public class Paciente
    {
        public int Id { get; set; }
        public int SucursalId { get; set; }

        [Required, MaxLength(20)]
        public string NumeroExpediente { get; set; }

        [Required, MaxLength(150)]
        public string Nombre { get; set; }

        [Required, MaxLength(150)]
        public string Apellidos { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required, MaxLength(10)]
        public string Sexo { get; set; } // Masculino, Femenino, Otro

        [MaxLength(20)]
        public string CURP { get; set; }

        [MaxLength(20)]
        public string RFC { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Telefono { get; set; }

        [MaxLength(20)]
        public string TelefonoEmergencia { get; set; }

        [MaxLength(200)]
        public string ContactoEmergencia { get; set; }

        [MaxLength(500)]
        public string Direccion { get; set; }

        [MaxLength(100)]
        public string Ciudad { get; set; }

        [MaxLength(100)]
        public string Estado { get; set; }

        [MaxLength(10)]
        public string CodigoPostal { get; set; }

        [MaxLength(100)]
        public string Ocupacion { get; set; }

        [MaxLength(50)]
        public string EstadoCivil { get; set; }

        [MaxLength(100)]
        public string GrupoSanguineo { get; set; }

        [MaxLength(500)]
        public string Foto { get; set; }

        public bool Activo { get; set; } = true;
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public DateTime? FechaModificacion { get; set; }

        // Relaciones EXISTENTES
        public Sucursal Sucursal { get; set; }

        public ICollection<Alergia> Alergias { get; set; }
        public ICollection<Antecedente> Antecedentes { get; set; }
        public ICollection<Cita> Citas { get; set; }
        public ICollection<Receta> Recetas { get; set; }
        public ICollection<OrdenLaboratorio> OrdenesLaboratorio { get; set; }
        public ICollection<OrdenImagen> OrdenesImagen { get; set; }
        public ICollection<Factura> Facturas { get; set; }
        public ICollection<HistoriaClinica> HistoriasClinicas { get; set; }
    }
}