global using EncoreTIX.Shared.Dtos;
global using EncoreTIX.Shared.Response;
global using EncoreTIX.Client.Services;
using EncoreTIX.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IAttractionService, AttractionService>();

await builder.Build().RunAsync();
