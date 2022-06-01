using Blazored.LocalStorage;
using CenedQualificando.Web.Admin.Services.ApiContracts;
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
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<StateContainer>();

            ConfigureRefitServices(builder);

            await builder.Build().RunAsync();
        }

        private static void ConfigureRefitServices(WebAssemblyHostBuilder builder)
        {
            const string urlBase = "https://localhost:6001/api/v1"; //"https://api-cenedqualificando.azurewebsites.net/api/v1";

            var settings = new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer()
            };

            builder.Services.AddRefitClient<IAgentePenitenciarioApiContract>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}/agentes-penitenciarios");
            });

            builder.Services.AddRefitClient<IAlunoApiContract>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}/alunos");
            });

            builder.Services.AddRefitClient<ICargaHorariaDiariaApiContract>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}/cargas-horarias-diarias");
            });

            builder.Services.AddRefitClient<IComboEntidadeApiContract>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}/combos/entidades");
            });

            builder.Services.AddRefitClient<IDocumentoConsultaApiContract>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}/documentos/consultas");
            });

            builder.Services.AddRefitClient<ICursoApiContract>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}/cursos");
            });

            builder.Services.AddRefitClient<IFiscalSalaApiContract>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}/fiscais-salas");
            });

            builder.Services.AddRefitClient<IGrupoDePermissaoApiContract>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}/grupos-permissoes");
            });

            builder.Services.AddRefitClient<IMatriculaApiContract>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}/matriculas");
            });

            builder.Services.AddRefitClient<IPenitenciariaApiContract>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}/penitenciarias");
            });

            builder.Services.AddRefitClient<IPermissaoApiContract>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}/permissoes");
            });

            builder.Services.AddRefitClient<IProvaApiContract>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}/provas");
            });

            builder.Services.AddRefitClient<IRepresentanteApiContract>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}/representantes");
            });

            builder.Services.AddRefitClient<IUfEntregaApiContract>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}/uf-entregas");
            });

            builder.Services.AddRefitClient<IUsuarioApiContract>(settings).ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri($"{urlBase}/usuarios");
            });
        }
    }
}
