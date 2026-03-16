using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Odontosoft.Frontend;
using Odontosoft.Frontend.Handlers;
using Odontosoft.Frontend.Repositories;
using Odontosoft.Frontend.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// ================= TENANT =================

builder.Services.AddScoped<TenantService>();
builder.Services.AddScoped<TenantHttpHandler>();

// ================= HTTP CLIENT =================

builder.Services.AddScoped(sp =>
{
    var tenantService = sp.GetRequiredService<TenantService>();

    var handler = new TenantHttpHandler(tenantService)
    {
        InnerHandler = new HttpClientHandler()
    };

    return new HttpClient(handler)
    {
        BaseAddress = new Uri("https://localhost:7297/")
    };
});

// ================= REPOSITORY =================

builder.Services.AddScoped<IRepository, Repository>();

// ================= UI =================

builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();