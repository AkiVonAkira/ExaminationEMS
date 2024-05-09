using BaseLibrary.Models;
using Blazored.LocalStorage;
using Blazored.Toast;
using Blazorise;
using Blazorise.FluentValidation;
using Blazorise.Icons.FontAwesome;
using Blazorise.Tailwind;
using Client;
using Client.ApplicationStates;
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

// Scopes for http and api endpoints
builder.Services.AddScoped<GetHttpClient>();
builder.Services.AddScoped<LocalDataStrorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();

// general department / department / section
builder.Services.AddScoped<IGenericServiceInterface<GeneralDepartment>, GenericServiceImplementations<GeneralDepartment>>();
builder.Services.AddScoped<IGenericServiceInterface<Department>, GenericServiceImplementations<Department>>();
builder.Services.AddScoped<IGenericServiceInterface<Section>, GenericServiceImplementations<Section>>();

// country / city / state
builder.Services.AddScoped<IGenericServiceInterface<Country>, GenericServiceImplementations<Country>>();
builder.Services.AddScoped<IGenericServiceInterface<City>, GenericServiceImplementations<City>>();
builder.Services.AddScoped<IGenericServiceInterface<State>, GenericServiceImplementations<State>>();

// employee
builder.Services.AddScoped<IGenericServiceInterface<Employee>, GenericServiceImplementations<Employee>>();

// table toggle states
builder.Services.AddScoped<DepartmentState>();

// Blazorise Services
builder.Services
  .AddBlazorise()
  .AddTailwindProviders()
  .AddFontAwesomeIcons()
  .AddBlazoriseFluentValidation()
  .AddBlazoredToast();

await builder.Build().RunAsync();