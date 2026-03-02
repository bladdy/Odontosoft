using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Services;

public class TenantService : ITenantService
{
    private Guid _tenantId = Guid.Empty;
    private string? _subdomain;

    public Guid TenantId => _tenantId;
    public string? Subdomain => _subdomain;

    public Task<Tenant?> GetByIdentifierAsync(string identifier)
    {
        // Ya no se usa aquí
        throw new NotImplementedException(
            "La resolución del tenant debe hacerse en el Middleware.");
    }

    public void SetTenant(Tenant tenant)
    {
        _tenantId = tenant.Id;
        _subdomain = tenant.Subdomain;
    }

    public void SetTenant(Guid tenantId, string subdomain)
    {
        _tenantId = tenantId;
        _subdomain = subdomain;
    }
}