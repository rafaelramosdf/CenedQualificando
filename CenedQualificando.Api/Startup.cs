using CenedQualificando.Api.Filters;
using CenedQualificando.Api.Services;
using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Domain.Interfaces.Requirements.Aluno;
using CenedQualificando.Domain.Interfaces.Requirements.Aluno.Exceptions;
using CenedQualificando.Domain.Interfaces.Requirements.Aluno.Functions;
using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Interfaces.UoW;
using CenedQualificando.Domain.Queries;
using CenedQualificando.Domain.Requirements.Aluno;
using CenedQualificando.Domain.Requirements.Aluno.Exceptions;
using CenedQualificando.Domain.Requirements.Aluno.Functions;
using CenedQualificando.Infra.Context;
using CenedQualificando.Infra.Repository;
using CenedQualificando.Infra.UoW;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CenedQualificando.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(options => 
            {
                options.Filters.Add(new ExceptionFilter());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CenedQualificando.Api", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyMethod();
                        builder.AllowAnyHeader();
                    });
            });

            services.AddAutoMapper(typeof(Startup));

            RegisterServices(services);
            RegisterRequirements(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CenedQualificando.Api v1"));
            }

            app.UseHsts();

            app.UseCors();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void RegisterServices(IServiceCollection services)
        {
            #region Service

            services.AddScoped<IAgentePenitenciarioService, AgentePenitenciarioService>();
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<ICargaHorariaDiariaService, CargaHorariaDiariaService>();
            services.AddScoped<ICursoService, CursoService>();
            services.AddScoped<IFiscalSalaService, FiscalSalaService>();
            services.AddScoped<IGrupoDePermissaoService, GrupoDePermissaoService>();
            services.AddScoped<IPermissaoService, PermissaoService>();
            services.AddScoped<IMatriculaService, MatriculaService>();
            services.AddScoped<IPenitenciariaService, PenitenciariaService>();
            services.AddScoped<IProvaService, ProvaService>();
            services.AddScoped<IRepresentanteService, RepresentanteService>();
            services.AddScoped<IUfEntregaService, UfEntregaService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            #endregion

            #region Domain

            services.AddScoped<IAgentePenitenciarioQuery, AgentePenitenciarioQuery>();
            services.AddScoped<IAlunoQuery, AlunoQuery>();
            services.AddScoped<ICargaHorariaDiariaQuery, CargaHorariaDiariaQuery>();
            services.AddScoped<ICursoQuery, CursoQuery>();
            services.AddScoped<IFiscalSalaQuery, FiscalSalaQuery>();
            services.AddScoped<IGrupoDePermissaoQuery, GrupoDePermissaoQuery>();
            services.AddScoped<IPermissaoQuery, PermissaoQuery>();
            services.AddScoped<IMatriculaQuery, MatriculaQuery>();
            services.AddScoped<IPenitenciariaQuery, PenitenciariaQuery>();
            services.AddScoped<IProvaQuery, ProvaQuery>();
            services.AddScoped<IRepresentanteQuery, RepresentanteQuery>();
            services.AddScoped<IUfEntregaQuery, UfEntregaQuery>();
            services.AddScoped<IUsuarioQuery, UsuarioQuery>();

            #endregion

            #region Infra

            services.AddDbContext<EntityContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbCened")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAgentePenitenciarioRepository, AgentePenitenciarioRepository>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<ICargaHorariaDiariaRepository, CargaHorariaDiariaRepository>();
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<IFiscalSalaRepository, FiscalSalaRepository>();
            services.AddScoped<IGrupoDePermissaoRepository, GrupoDePermissaoRepository>();
            services.AddScoped<IPermissaoRepository, PermissaoRepository>();
            services.AddScoped<IMatriculaRepository, MatriculaRepository>();
            services.AddScoped<IPenitenciariaRepository, PenitenciariaRepository>();
            services.AddScoped<IProvaRepository, ProvaRepository>();
            services.AddScoped<IRepresentanteRepository, RepresentanteRepository>();
            services.AddScoped<IUfEntregaRepository, UfEntregaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            #endregion
        }

        private void RegisterRequirements(IServiceCollection services) 
        {
            #region Aluno
            services.AddScoped<IIncluirAlunoRequirement, IncluirAlunoRequirement>();
            services.AddScoped<IGeraSenhaInicialAlunoFunction, GeraSenhaInicialAlunoFunction>();
            services.AddScoped<ICpfDuplicadoAlunoException, CpfDuplicadoAlunoException>();
            #endregion
        }
    }
}
