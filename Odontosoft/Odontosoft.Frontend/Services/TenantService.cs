using Microsoft.AspNetCore.Components;

namespace Odontosoft.Frontend.Services;

public class TenantService
{
    private readonly NavigationManager _navigation;

    public TenantService(NavigationManager navigation)
    {
        _navigation = navigation;
    }

    public string GetTenant()
    {
        var uri = new Uri(_navigation.Uri);
        var host = uri.Host;

        if (host.Contains("localhost"))
            return "demo";

        var parts = host.Split('.');
        return parts[0];
    }
}