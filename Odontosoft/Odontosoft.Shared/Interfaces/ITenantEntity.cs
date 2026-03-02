namespace Odontosoft.Shared.Interfaces;

public interface ITenantEntity : IBaseEntity
{
    Guid TenantId { get; set; }
}