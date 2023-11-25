using IdentityDemo.BlazorWasmAuth;
using IdentityDemo.BlazorWasmAuth.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped<CookieAuthenticationHandler>();

// set up authorization
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<AuthenticationStateProvider, CookieAuthenticationStateProvider>();

builder.Services.AddScoped(serviceProvider => (IAuthenticationManager)serviceProvider.GetRequiredService<AuthenticationStateProvider>());


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient(
    "Identity",
    opt => opt.BaseAddress = new Uri("https://localhost:7116"))
    .AddHttpMessageHandler<CookieAuthenticationHandler>();

await builder.Build().RunAsync();
