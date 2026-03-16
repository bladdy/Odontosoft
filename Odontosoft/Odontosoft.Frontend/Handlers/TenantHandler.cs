using System.Net.Http;
using Odontosoft.Frontend.Services;

namespace Odontosoft.Frontend.Handlers;

public class TenantHttpHandler : DelegatingHandler
{
    private readonly TenantService _tenantService;

    public TenantHttpHandler(TenantService tenantService)
    {
        _tenantService = tenantService;
    }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var tenant = _tenantService.GetTenant();

        if (!request.Headers.Contains("X-Tenant"))
        {
            request.Headers.Add("X-Tenant", tenant);
        }

        return base.SendAsync(request, cancellationToken);
    }
}