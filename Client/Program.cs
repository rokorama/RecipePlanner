global using RecipePlanner.Shared;
global using System.Net.Http.Json;
global using RecipePlanner.Client.Services.RecipeService;
global using RecipePlanner.Client.Services.AuthService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RecipePlanner.Client;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddMudServices();

await builder.Build().RunAsync();
