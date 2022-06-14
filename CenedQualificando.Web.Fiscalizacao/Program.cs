using Blazored.LocalStorage;
using CenedQualificando.Web.Fiscalizacao;
using CenedQualificando.Web.Fiscalizacao.Services.ApiContracts;
using CenedQualificando.Web.Fiscalizacao.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Refit;
using System;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<StateContainer>();

string urlBase = builder.Configuration["UrlBaseApi"];

var settings = new RefitSettings
{
    ContentSerializer = new NewtonsoftJsonContentSerializer()
};

builder.Services.AddRefitClient<IComboEntidadeApiContract>(settings)
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri($"{urlBase}/combos");
    });

builder.Services.AddRefitClient<IMatriculaApiContract>(settings)
    .ConfigureHttpClient(c => 
    { 
        c.BaseAddress = new Uri($"{urlBase}/matriculas"); 
    });

builder.Services.AddRefitClient<IPenitenciariaApiContract>(settings)
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri($"{urlBase}/penitenciarias");
    });

await builder.Build().RunAsync();
