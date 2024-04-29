using Blazored.LocalStorage;
using Blazorise;
using Blazorise.FluentValidation;
using Blazorise.Icons.FontAwesome;
using Blazorise.Tailwind;
using Client;
using ClientLibrary.Helpers;
using ClientLibrary.Services.Contracts;
using ClientLibrary.Services.Implementations;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<CustomHttpHandler>();
builder.Services.AddHttpClient("ServerApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7075/");
}).AddHttpMessageHandler<CustomHttpHandler>(); ;

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7075") });

builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<GetHttpClient>();
builder.Services.AddScoped<LocalDataStrorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();

builder.Services
  .AddBlazorise()
  .AddTailwindProviders()
  .AddFontAwesomeIcons()
  .AddBlazoriseFluentValidation();

await builder.Build().RunAsync();