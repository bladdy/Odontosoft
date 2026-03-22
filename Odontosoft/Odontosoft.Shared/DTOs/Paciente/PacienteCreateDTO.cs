using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.DTOs.Paciente;

public class PacienteCreateDTO
{
    public Guid Id { get; set; }
    public Guid SucursalId { get; set; }

    [MaxLength(20)]
    public string NumeroExpediente { get; set; }

    [Display(Name = "Nombre")]
    [Required(ErrorMessage = "El campo {0} es obligatorio."), MaxLength(150)]
    public string Nombre { get; set; }

    [Display(Name = "Apellidos")]
    [Required(ErrorMessage = "El campo {0} es obligatorio."), MaxLength(150)]
    public string Apellidos { get; set; }

    [Display(Name = "Fecha Nacimiento")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public DateTime FechaNacimiento { get; set; } = new DateTime(1900, 1, 1);

    [Display(Name = "Genero")]
    [Required(ErrorMessage = "El campo {0} es obligatorio."), MaxLength(10)]
    public string Sexo { get; set; }

    [Display(Name = "Documento")]
    [Required(ErrorMessage = "El campo {0} es obligatorio."), MaxLength(20)]
    public string? CURP { get; set; }

    [Display(Name = "RFC")]
    [MaxLength(20)]
    public string? RFC { get; set; }

    [Display(Name = "Email")]
    [Required(ErrorMessage = "El campo {0} es obligatorio."), MaxLength(200)]
    public string? Email { get; set; }

    [Display(Name = "Telefono")]
    [Required(ErrorMessage = "El campo {0} es obligatorio."), MaxLength(20)]
    public string? Telefono { get; set; }

    [Display(Name = "Telefono Emergencia")]
    [Required(ErrorMessage = "El campo {0} es obligatorio."), MaxLength(20)]
    public string? TelefonoEmergencia { get; set; }

    [Display(Name = "Contacto Emergencia")]
    [Required(ErrorMessage = "El campo {0} es obligatorio."), MaxLength(200)]
    public string? ContactoEmergencia { get; set; }

    [Display(Name = "Direccion")]
    [Required(ErrorMessage = "El campo {0} es obligatorio."), MaxLength(500)]
    public string? Direccion { get; set; }

    [Display(Name = "Ciudad")]
    [Required(ErrorMessage = "El campo {0} es obligatorio."), MaxLength(100)]
    public string? Ciudad { get; set; }

    [Display(Name = "Estado")]
    [Required(ErrorMessage = "El campo {0} es obligatorio."), MaxLength(100)]
    public string? Estado { get; set; }

    [Display(Name = "Codigo Postal")]
    [Required(ErrorMessage = "El campo {0} es obligatorio."), MaxLength(10)]
    public string? CodigoPostal { get; set; }

    [Display(Name = "Ocupación")]
    [Required(ErrorMessage = "El campo {0} es obligatorio."), MaxLength(100)]
    public string? Ocupacion { get; set; }

    [Display(Name = "Estado Civil")]
    [Required(ErrorMessage = "El campo {0} es obligatorio."), MaxLength(50)]
    public string? EstadoCivil { get; set; }

    [Display(Name = "Grupo Sanguineo")]
    [Required(ErrorMessage = "El campo {0} es obligatorio."), MaxLength(100)]
    public string? GrupoSanguineo { get; set; }

    public string? Foto { get; set; }

    public bool Activo { get; set; } = true;
}