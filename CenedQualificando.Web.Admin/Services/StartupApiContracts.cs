using CenedQualificando.Web.Admin.Services.ApiContracts;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;

namespace CenedQualificando.Web.Admin.Services
{
    public static class StartupApiContracts
    {
        public static void ConfigureRefitServices(WebAssemblyHostBuilder builder)
        {
            string urlBase = builder.Configuration["UrlBaseApi"];

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
                c.BaseAddress = new Uri($"{urlBase}/combos");
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
