namespace Odontosoft.Shared.DTOs.Paciente;

public class PacienteResponseDTO
{
    public Guid Id { get; set; }

    public Guid SucursalId { get; set; }

    public string NumeroExpediente { get; set; }

    public string Nombre { get; set; }

    public string Apellidos { get; set; }

    public DateTime FechaNacimiento { get; set; }

    public string Sexo { get; set; }

    public string? CURP { get; set; }

    public string? RFC { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public string? Ciudad { get; set; }

    public string? Estado { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaRegistro { get; set; }
}