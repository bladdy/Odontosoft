using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Services;

public interface ITenantService
{
    Guid TenantId { get; }
    string? Subdomain { get; }

    Task<Tenant?> GetByIdentifierAsync(string identifier);

    void SetTenant(Tenant tenant);

    void SetTenant(Guid tenantId, string subdomain);
}