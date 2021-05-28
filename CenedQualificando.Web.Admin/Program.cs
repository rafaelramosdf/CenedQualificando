using CenedQualificando.Web.Admin.Services;
using CenedQualificando.Web.Admin.Services.Contracts;
using CenedQualificando.Web.Admin.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
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

            builder.Services.AddScoped<IAgentePenitenciarioService, AgentePenitenciarioService>();
            builder.Services.AddScoped<IAlunoService, AlunoService>();
            builder.Services.AddScoped<ICargaHorariaDiariaService, CargaHorariaDiariaService>();
            builder.Services.AddScoped<IComboEntidadeService, ComboEntidadeService>();
            builder.Services.AddScoped<ICursoService, CursoService>();
            builder.Services.AddScoped<IFiscalSalaService, FiscalSalaService>();
            builder.Services.AddScoped<IGrupoDePermissaoService, GrupoDePermissaoService>();
            builder.Services.AddScoped<IMatriculaService, MatriculaService>();
            builder.Services.AddScoped<IPenitenciariaService, PenitenciariaService>();
            builder.Services.AddScoped<IPermissaoService, PermissaoService>();
            builder.Services.AddScoped<IProvaService, ProvaService>();
            builder.Services.AddScoped<IRepresentanteService, RepresentanteService>();
            builder.Services.AddScoped<IUfEntregaService, UfEntregaService>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();

            await builder.Build().RunAsync();
        }
    }
}
