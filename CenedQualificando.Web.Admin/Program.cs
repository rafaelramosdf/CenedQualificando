using CenedQualificando.Web.Admin.Services.RefitApiServices;
using CenedQualificando.Web.Admin.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddMudServices();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<StateContainer>();

            ConfigureRefitServices(builder);

            await builder.Build().RunAsync();
        }

        private static void ConfigureRefitServices(WebAssemblyHostBuilder builder)
        {
            const string urlBase = "https://localhost:6001/api";

            var settings = new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer()
            };

            builder.Services.AddRefitClient<IAgentePenitenciarioApiService>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}");
            });

            builder.Services.AddRefitClient<IAlunoApiService>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}");
            });

            builder.Services.AddRefitClient<ICargaHorariaDiariaApiService>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}");
            });

            builder.Services.AddRefitClient<IComboEntidadeApiService>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}/combos/entidades");
            });

            builder.Services.AddRefitClient<IConsultaApiService>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}/consultas");
            });

            builder.Services.AddRefitClient<ICursoApiService>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}");
            });

            builder.Services.AddRefitClient<IFiscalSalaApiService>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}");
            });

            builder.Services.AddRefitClient<IGrupoDePermissaoApiService>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}");
            });

            builder.Services.AddRefitClient<IMatriculaApiService>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}");
            });

            builder.Services.AddRefitClient<IPenitenciariaApiService>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}");
            });

            builder.Services.AddRefitClient<IPermissaoApiService>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}");
            });

            builder.Services.AddRefitClient<IProvaApiService>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}");
            });

            builder.Services.AddRefitClient<IRepresentanteApiService>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}");
            });

            builder.Services.AddRefitClient<IUfEntregaApiService>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}");
            });

            builder.Services.AddRefitClient<IUsuarioApiService>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}");
            });
        }
    }
}
