using System.ComponentModel.DataAnnotations;

namespace Odontosoft.Shared.DTOs.Paciente;

public class PacienteCreateDTO
{
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

    [Required, MaxLength(20)]
    public string? CURP { get; set; }

    [Required, MaxLength(20)]
    public string? RFC { get; set; }

    [Required, MaxLength(200)]
    public string? Email { get; set; }

    [Required, MaxLength(20)]
    public string? Telefono { get; set; }

    [Required, MaxLength(20)]
    public string? TelefonoEmergencia { get; set; }

    [Required, MaxLength(200)]
    public string? ContactoEmergencia { get; set; }

    [Required, MaxLength(500)]
    public string? Direccion { get; set; }

    [Required, MaxLength(100)]
    public string? Ciudad { get; set; }

    [Required, MaxLength(100)]
    public string? Estado { get; set; }

    [Required, MaxLength(10)]
    public string? CodigoPostal { get; set; }

    [Required, MaxLength(100)]
    public string? Ocupacion { get; set; }

    [Required, MaxLength(50)]
    public string? EstadoCivil { get; set; }

    [Required, MaxLength(100)]
    public string? GrupoSanguineo { get; set; }

    [Required, MaxLength(500)]
    public string? Foto { get; set; }

    public bool Activo { get; set; } = true;
}