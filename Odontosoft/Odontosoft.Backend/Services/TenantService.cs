using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Services;

public class TenantService : ITenantService
{
    private Guid _tenantId = Guid.Empty;
    private string? _subdomain;
    private bool _isSet;

    public Guid TenantId
    {
        get
        {
            if (!_isSet)
                throw new InvalidOperationException("Tenant no ha sido resuelto.");

            return _tenantId;
        }
    }

    public string? Subdomain => _subdomain;

    public bool HasTenant => _isSet;

    public Task<Tenant?> GetByIdentifierAsync(string identifier)
    {
        throw new NotImplementedException(
            "La resolución del tenant se realiza en el TenantMiddleware.");
    }

    public void SetTenant(Tenant tenant)
    {
        if (tenant == null)
            throw new ArgumentNullException(nameof(tenant));

        if (_isSet)
            return;

        _tenantId = tenant.Id;
        _subdomain = tenant.Subdomain;
        _isSet = true;
    }

    public void SetTenant(Guid tenantId, string subdomain)
    {
        if (_isSet)
            return;

        _tenantId = tenantId;
        _subdomain = subdomain;
        _isSet = true;
    }
}