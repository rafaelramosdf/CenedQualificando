using CenedQualificando.Api.Filters;
using CenedQualificando.Domain.Handlers.AgentePenitenciario;
using CenedQualificando.Domain.Handlers.Aluno;
using CenedQualificando.Domain.Handlers.CargaHorariaDiaria;
using CenedQualificando.Domain.Handlers.Curso;
using CenedQualificando.Domain.Handlers.FiscalSala;
using CenedQualificando.Domain.Handlers.GrupoDePermissao;
using CenedQualificando.Domain.Handlers.Matricula;
using CenedQualificando.Domain.Handlers.Penitenciaria;
using CenedQualificando.Domain.Handlers.Permissao;
using CenedQualificando.Domain.Handlers.Prova;
using CenedQualificando.Domain.Handlers.Representante;
using CenedQualificando.Domain.Handlers.UfEntrega;
using CenedQualificando.Domain.Handlers.Usuario;
using CenedQualificando.Domain.Queries;
using CenedQualificando.Domain.Queries.Contracts;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using CenedQualificando.Infra.Context;
using CenedQualificando.Infra.Repository;
using CenedQualificando.Infra.UoW;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

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

            var key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("PrivateKey"));
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "API CENED QUALIFICANDO", 
                    Version = "v1",
                    Description = "API para consumo das funcionalidades do sistema de " +
                    "ensino a distancia CENED Qualificando.",
                    Contact = new OpenApiContact 
                    {
                        Name = ": Rafael Ramos | rafaelramosdf@gmail.com",
                        Email = "rafaelramosdf@gmail.com"
                    }
                });

                c.EnableAnnotations();
                c.SchemaFilter<SwaggerEnumDescriptionFilter>();
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

            RegisterRepositories(services);
            RegisterQueries(services);
            RegisterHandlers(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CenedQualificando.Api v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHsts();

            app.UseCors();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void RegisterRepositories(IServiceCollection services)
        {
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
        }

        private void RegisterQueries(IServiceCollection services)
        {
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
        }

        private void RegisterHandlers(IServiceCollection services)
        {
            #region Aluno
            services.AddScoped<IAlterarAlunoCommandHandler, AlterarAlunoCommandHandler>();
            services.AddScoped<IBuscarAlunoPorIdQueryHandler, BuscarAlunoPorIdQueryHandler>();
            services.AddScoped<IObterDataTableAlunosQueryHandler, ObterDataTableAlunosQueryHandler>();
            services.AddScoped<IObterComboSelecaoAlunosQueryHandler, ObterComboSelecaoAlunosQueryHandler>();
            services.AddScoped<IExcluirAlunoCommandHandler, ExcluirAlunoCommandHandler>();
            services.AddScoped<IIncluirAlunoCommandHandler, IncluirAlunoCommandHandler>();
            #endregion

            #region AgentePenitenciario
            services.AddScoped<IAlterarAgentePenitenciarioCommandHandler, AlterarAgentePenitenciarioCommandHandler>();
            services.AddScoped<IBuscarAgentePenitenciarioPorIdQueryHandler, BuscarAgentePenitenciarioPorIdQueryHandler>();
            services.AddScoped<IObterDataTableAgentesPenitenciariosQueryHandler, ObterDataTableAgentesPenitenciariosQueryHandler>();
            services.AddScoped<IObterComboSelecaoAgentesPenitenciariosQueryHandler, ObterComboSelecaoAgentesPenitenciariosQueryHandler>();
            services.AddScoped<IExcluirAgentePenitenciarioCommandHandler, ExcluirAgentePenitenciarioCommandHandler>();
            services.AddScoped<IIncluirAgentePenitenciarioCommandHandler, IncluirAgentePenitenciarioCommandHandler>();
            #endregion

            #region CargaHorariaDiaria
            services.AddScoped<IAlterarCargaHorariaDiariaCommandHandler, AlterarCargaHorariaDiariaCommandHandler>();
            services.AddScoped<IBuscarCargaHorariaDiariaPorIdQueryHandler, BuscarCargaHorariaDiariaPorIdQueryHandler>();
            services.AddScoped<IObterDataTableCargaHorariaDiariaQueryHandler, ObterDataTableCargaHorariaDiariaQueryHandler>();
            services.AddScoped<IExcluirCargaHorariaDiariaCommandHandler, ExcluirCargaHorariaDiariaCommandHandler>();
            services.AddScoped<IIncluirCargaHorariaDiariaCommandHandler, IncluirCargaHorariaDiariaCommandHandler>();
            #endregion

            #region Curso
            services.AddScoped<IAlterarCursoCommandHandler, AlterarCursoCommandHandler>();
            services.AddScoped<IBuscarCursoPorIdQueryHandler, BuscarCursoPorIdQueryHandler>();
            services.AddScoped<IObterDataTableCursosQueryHandler, ObterDataTableCursosQueryHandler>();
            services.AddScoped<IObterComboSelecaoCursosQueryHandler, ObterComboSelecaoCursosQueryHandler>();
            services.AddScoped<IExcluirCursoCommandHandler, ExcluirCursoCommandHandler>();
            services.AddScoped<IIncluirCursoCommandHandler, IncluirCursoCommandHandler>();
            #endregion

            #region FiscalSala
            services.AddScoped<IAlterarFiscalSalaCommandHandler, AlterarFiscalSalaCommandHandler>();
            services.AddScoped<IBuscarFiscalSalaPorIdQueryHandler, BuscarFiscalSalaPorIdQueryHandler>();
            services.AddScoped<IObterDataTableFiscalSalaQueryHandler, ObterDataTableFiscalSalaQueryHandler>();
            services.AddScoped<IObterComboSelecaoFiscalSalaQueryHandler, ObterComboSelecaoFiscalSalaQueryHandler>();
            services.AddScoped<IExcluirFiscalSalaCommandHandler, ExcluirFiscalSalaCommandHandler>();
            services.AddScoped<IIncluirFiscalSalaCommandHandler, IncluirFiscalSalaCommandHandler>();
            #endregion

            #region GrupoDePermissao
            services.AddScoped<IAlterarGrupoDePermissaoCommandHandler, AlterarGrupoDePermissaoCommandHandler>();
            services.AddScoped<IBuscarGrupoDePermissaoPorIdQueryHandler, BuscarGrupoDePermissaoPorIdQueryHandler>();
            services.AddScoped<IObterDataTableGrupoDePermissaosQueryHandler, ObterDataTableGrupoDePermissaosQueryHandler>();
            services.AddScoped<IObterComboSelecaoGrupoDePermissaosQueryHandler, ObterComboSelecaoGrupoDePermissaosQueryHandler>();
            services.AddScoped<IExcluirGrupoDePermissaoCommandHandler, ExcluirGrupoDePermissaoCommandHandler>();
            services.AddScoped<IIncluirGrupoDePermissaoCommandHandler, IncluirGrupoDePermissaoCommandHandler>();
            #endregion

            #region Matricula
            services.AddScoped<IAlterarMatriculaCommandHandler, AlterarMatriculaCommandHandler>();
            services.AddScoped<IBuscarMatriculaPorIdQueryHandler, BuscarMatriculaPorIdQueryHandler>();
            services.AddScoped<IObterDocumentoConsultaMatriculasQueryHandler, ObterDocumentoConsultaMatriculasQueryHandler>();
            services.AddScoped<IObterDataTableMatriculasQueryHandler, ObterDataTableMatriculasQueryHandler>();
            services.AddScoped<IExcluirMatriculaCommandHandler, ExcluirMatriculaCommandHandler>();
            services.AddScoped<IIncluirMatriculaCommandHandler, IncluirMatriculaCommandHandler>();
            #endregion

            #region Penitenciaria
            services.AddScoped<IAlterarPenitenciariaCommandHandler, AlterarPenitenciariaCommandHandler>();
            services.AddScoped<IBuscarPenitenciariaPorIdQueryHandler, BuscarPenitenciariaPorIdQueryHandler>();
            services.AddScoped<IObterDataTablePenitenciariasQueryHandler, ObterDataTablePenitenciariasQueryHandler>();
            services.AddScoped<IObterComboSelecaoPenitenciariasQueryHandler, ObterComboSelecaoPenitenciariasQueryHandler>();
            services.AddScoped<IObterComboSelecaoPenitenciariasComFiltroQueryHandler, ObterComboSelecaoPenitenciariasComFiltroQueryHandler>();
            services.AddScoped<IExcluirPenitenciariaCommandHandler, ExcluirPenitenciariaCommandHandler>();
            services.AddScoped<IIncluirPenitenciariaCommandHandler, IncluirPenitenciariaCommandHandler>();
            #endregion

            #region Permissao
            services.AddScoped<IAlterarPermissaoCommandHandler, AlterarPermissaoCommandHandler>();
            services.AddScoped<IBuscarPermissaoPorIdQueryHandler, BuscarPermissaoPorIdQueryHandler>();
            services.AddScoped<IObterDataTablePermissaosQueryHandler, ObterDataTablePermissaosQueryHandler>();
            services.AddScoped<IExcluirPermissaoCommandHandler, ExcluirPermissaoCommandHandler>();
            services.AddScoped<IIncluirPermissaoCommandHandler, IncluirPermissaoCommandHandler>();
            #endregion

            #region Prova
            services.AddScoped<IAlterarProvaCommandHandler, AlterarProvaCommandHandler>();
            services.AddScoped<IBuscarProvaPorIdQueryHandler, BuscarProvaPorIdQueryHandler>();
            services.AddScoped<IBuscarProvasPorIdMatriculasQueryHandler, BuscarProvasPorIdMatriculasQueryHandler>();
            services.AddScoped<IObterDataTableProvasQueryHandler, ObterDataTableProvasQueryHandler>();
            services.AddScoped<IExcluirProvaCommandHandler, ExcluirProvaCommandHandler>();
            services.AddScoped<IIncluirProvaCommandHandler, IncluirProvaCommandHandler>();
            #endregion

            #region Representante
            services.AddScoped<IAlterarRepresentanteCommandHandler, AlterarRepresentanteCommandHandler>();
            services.AddScoped<IBuscarRepresentantePorIdQueryHandler, BuscarRepresentantePorIdQueryHandler>();
            services.AddScoped<IObterDataTableRepresentantesQueryHandler, ObterDataTableRepresentantesQueryHandler>();
            services.AddScoped<IObterComboSelecaoRepresentantesQueryHandler, ObterComboSelecaoRepresentantesQueryHandler>();
            services.AddScoped<IExcluirRepresentanteCommandHandler, ExcluirRepresentanteCommandHandler>();
            services.AddScoped<IIncluirRepresentanteCommandHandler, IncluirRepresentanteCommandHandler>();
            #endregion

            #region UfEntrega
            services.AddScoped<IAlterarUfEntregaCommandHandler, AlterarUfEntregaCommandHandler>();
            services.AddScoped<IBuscarUfEntregaPorIdQueryHandler, BuscarUfEntregaPorIdQueryHandler>();
            services.AddScoped<IObterDataTableUfEntregasQueryHandler, ObterDataTableUfEntregasQueryHandler>();
            services.AddScoped<IExcluirUfEntregaCommandHandler, ExcluirUfEntregaCommandHandler>();
            services.AddScoped<IIncluirUfEntregaCommandHandler, IncluirUfEntregaCommandHandler>();
            #endregion

            #region Usuario
            services.AddScoped<IAlterarUsuarioCommandHandler, AlterarUsuarioCommandHandler>();
            services.AddScoped<IBuscarUsuarioPorIdQueryHandler, BuscarUsuarioPorIdQueryHandler>();
            services.AddScoped<IObterDataTableUsuariosQueryHandler, ObterDataTableUsuariosQueryHandler>();
            services.AddScoped<IObterComboSelecaoUsuariosQueryHandler, ObterComboSelecaoUsuariosQueryHandler>();
            services.AddScoped<IExcluirUsuarioCommandHandler, ExcluirUsuarioCommandHandler>();
            services.AddScoped<IIncluirUsuarioCommandHandler, IncluirUsuarioCommandHandler>();
            services.AddScoped<IAutenticarUsuarioCommandHandler, AutenticarUsuarioCommandHandler>();
            #endregion
        }
    }
}
