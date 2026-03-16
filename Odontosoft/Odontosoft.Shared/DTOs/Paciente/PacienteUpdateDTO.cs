using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.DTOs.Paciente;

public class PacienteUpdateDTO
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public Guid SucursalId { get; set; }

    [Required, MaxLength(20)]
    public string NumeroExpediente { get; set; }

    [Required, MaxLength(150)]
    public string Nombre { get; set; }

    [Required, MaxLength(150)]
    public string Apellidos { get; set; }

    [Required]
    public DateTime FechaNacimiento { get; set; }

    [Required, MaxLength(10)]
    public string Sexo { get; set; }

    public string? CURP { get; set; }
    public string? RFC { get; set; }
    public string? Email { get; set; }
    public string? Telefono { get; set; }
    public string? TelefonoEmergencia { get; set; }
    public string? ContactoEmergencia { get; set; }
    public string? Direccion { get; set; }
    public string? Ciudad { get; set; }
    public string? Estado { get; set; }
    public string? CodigoPostal { get; set; }
    public string? Ocupacion { get; set; }
    public string? EstadoCivil { get; set; }
    public string? GrupoSanguineo { get; set; }
    public string? Foto { get; set; }

    public bool Activo { get; set; }
}