namespace Odontosoft.Shared.DTOs;

public class PaginationDTO
{
    public Guid Id { get; set; }

    public int Page { get; set; } = 1;

    public int RecordsNumber { get; set; } = 10;

    public string? Filter { get; set; }
}