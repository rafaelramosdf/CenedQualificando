using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CenedQualificando.Infra.Context
{
    public partial class EntityContext : DbContext
    {
        const string StrConnLocal = "Data Source=.;Initial Catalog=DbCenedLocal;Integrated Security=True";

        public EntityContext()
        {
        }

        public EntityContext(DbContextOptions<EntityContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(StrConnLocal,
                    x => x.MigrationsHistoryTable("__MigrationHistory", "Penitenciario"));
            }
        }

        public virtual DbSet<AgentePenitenciario> AgentePenitenciario { get; set; }
        public virtual DbSet<AgentePenitenciarioParceria> AgentePenitenciarioParceria { get; set; }
        public virtual DbSet<AgentePenitenciarioParceriaPagamentos> AgentePenitenciarioParceriaPagamentos { get; set; }
        public virtual DbSet<Aluno> Aluno { get; set; }
        public virtual DbSet<CargaHorariaDiaria> CargaHorariaDiaria { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<CursoUf> CursoUf { get; set; }
        public virtual DbSet<CursoUfCurso> CursoUfCurso { get; set; }
        public virtual DbSet<DeclaracaoCursosConcluidos> DeclaracaoCursosConcluidos { get; set; }
        public virtual DbSet<DespesaExtra> DespesaExtra { get; set; }
        public virtual DbSet<EstoqueMaterial> EstoqueMaterial { get; set; }
        public virtual DbSet<FiscalSala> FiscalSala { get; set; }
        public virtual DbSet<GrupoDePermissao> GrupoDePermissao { get; set; }
        public virtual DbSet<GrupoProva> GrupoProva { get; set; }
        public virtual DbSet<GruposProvaUf> GruposProvaUf { get; set; }
        public virtual DbSet<GruposProvaUfCurso> GruposProvaUfCurso { get; set; }
        public virtual DbSet<HistoricoCurso> HistoricoCurso { get; set; }
        public virtual DbSet<ImpressaoCertificado> ImpressaoCertificado { get; set; }
        public virtual DbSet<LogAuditoria> LogAuditoria { get; set; }
        public virtual DbSet<Matricula> Matricula { get; set; }
        public virtual DbSet<Mensagem> Mensagem { get; set; }
        public virtual DbSet<MensagemPersonalizada> MensagemPersonalizada { get; set; }
        public virtual DbSet<NumeroCertificado> NumeroCertificado { get; set; }
        public virtual DbSet<NumeroMatricula> NumeroMatricula { get; set; }
        public virtual DbSet<NumeroOficio> NumeroOficio { get; set; }
        public virtual DbSet<Penitenciaria> Penitenciaria { get; set; }
        public virtual DbSet<Permissao> Permissao { get; set; }
        public virtual DbSet<Prova> Prova { get; set; }
        public virtual DbSet<Representante> Representante { get; set; }
        public virtual DbSet<SolicitacaoAutorizacaoMatricula> SolicitacaoAutorizacaoMatricula { get; set; }
        public virtual DbSet<SolicitacaoAutorizacaoMatriculaCursos> SolicitacaoAutorizacaoMatriculaCursos { get; set; }
        public virtual DbSet<SolicitacaoCertificado> SolicitacaoCertificado { get; set; }
        public virtual DbSet<TabelaCursosAutorizados> TabelaCursosAutorizados { get; set; }
        public virtual DbSet<TabelaHistoricoCurso> TabelaHistoricoCurso { get; set; }
        public virtual DbSet<Token> Token { get; set; }
        public virtual DbSet<Transacao> Transacao { get; set; }
        public virtual DbSet<TransacaoCieloSolicitacaoCertificado> TransacaoCieloSolicitacaoCertificado { get; set; }
        public virtual DbSet<UfEntrega> UfEntrega { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.HasSequence<int>("SequencialUsuario").StartsAt(34).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new FiscalSalaMap());
            modelBuilder.HasSequence<int>("SequencialFiscalSala").StartsAt(17).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new AgentePenitenciarioMap());
            modelBuilder.HasSequence<int>("SequencialAgentePenitenciario").StartsAt(35).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new AgentePenitenciarioParceriaMap());
            modelBuilder.HasSequence<int>("SequencialAgentePenitenciarioParceria").StartsAt(16).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new AgentePenitenciarioParceriaPagamentosMap());
            modelBuilder.HasSequence<int>("SequencialAgentePenitenciarioParceriaPagamentos").StartsAt(1).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.HasSequence<int>("SequencialAluno").StartsAt(9482).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new CargaHorariaDiariaMap());
            modelBuilder.HasSequence<int>("SequencialCargaHorariaDiaria").StartsAt(32).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new CursoMap());
            modelBuilder.HasSequence<int>("SequencialCurso").StartsAt(138).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new CursoUfMap());
            modelBuilder.HasSequence<int>("SequencialCursoUf").StartsAt(343).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new CursoUfCursoMap());

            modelBuilder.ApplyConfiguration(new DeclaracaoCursosConcluidosMap());
            modelBuilder.HasSequence<int>("SequencialDeclaracaoCursosConcluidos").StartsAt(222).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new DespesaExtraMap());
            modelBuilder.HasSequence<int>("SequencialDespesaExtra").StartsAt(866).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new EstoqueMaterialMap());
            modelBuilder.HasSequence<int>("SequencialEstoqueMaterial").StartsAt(92).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new GrupoDePermissaoMap());
            modelBuilder.HasSequence<int>("SequencialGrupoDePermissao").StartsAt(12).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new GrupoProvaMap());
            modelBuilder.HasSequence<int>("SequencialGrupoProva").StartsAt(3).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new GruposProvaUfMap());
            modelBuilder.HasSequence<int>("SequencialGruposProvaUf").StartsAt(7).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new GruposProvaUfCursoMap());

            modelBuilder.ApplyConfiguration(new HistoricoCursoMap());
            modelBuilder.HasSequence<int>("SequencialHistoricoCurso").StartsAt(379998).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new ImpressaoCertificadoMap());
            modelBuilder.HasSequence<int>("SequencialImpressaoCertificado").StartsAt(121).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new LogAuditoriaMap());
            modelBuilder.HasSequence<int>("SequencialLogAuditoria").StartsAt(8104).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new MatriculaMap());
            modelBuilder.HasSequence<int>("SequencialMatricula").StartsAt(30010).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new MensagemMap());
            modelBuilder.HasSequence<int>("SequencialMensagem").StartsAt(1422).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new MensagemPersonalizadaMap());
            modelBuilder.HasSequence<int>("SequencialMensagemPersonalizada").StartsAt(3).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new NumeroCertificadoMap());
            modelBuilder.HasSequence<int>("SequencialNumeroCertificado").StartsAt(19906).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new NumeroMatriculaMap());
            modelBuilder.HasSequence<int>("SequencialNumeroMatricula").StartsAt(24838).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new NumeroOficioMap());
            modelBuilder.HasSequence<int>("SequencialNumeroOficio").StartsAt(1543).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new PenitenciariaMap());
            modelBuilder.HasSequence<int>("SequencialPenitenciaria").StartsAt(385).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new PermissaoMap());
            modelBuilder.HasSequence<int>("SequencialPermissao").StartsAt(1235).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new ProvaMap());
            modelBuilder.HasSequence<int>("SequencialProva").StartsAt(26438).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new RepresentanteMap());
            modelBuilder.HasSequence<int>("SequencialRepresentante").StartsAt(10).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new SolicitacaoAutorizacaoMatriculaMap());
            modelBuilder.HasSequence<int>("SequencialSolicitacaoAutorizacaoMatricula").StartsAt(366).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new SolicitacaoAutorizacaoMatriculaCursosMap());
            modelBuilder.HasSequence<int>("SequencialSolicitacaoAutorizacaoMatriculaCursos").StartsAt(469).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new SolicitacaoCertificadoMap());
            modelBuilder.HasSequence<int>("SequencialSolicitacaoCertificado").StartsAt(2500).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new TabelaCursosAutorizadosMap());
            modelBuilder.HasSequence<int>("SequencialTabelaCursosAutorizados").StartsAt(3119).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new TabelaHistoricoCursoMap());
            modelBuilder.HasSequence<int>("SequencialTabelaHistoricoCurso").StartsAt(16).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new TokenMap());
            modelBuilder.HasSequence<int>("SequencialToken").StartsAt(2817).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new TransacaoMap());
            modelBuilder.HasSequence<int>("SequencialTransacao").StartsAt(24394).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new TransacaoCieloSolicitacaoCertificadoMap());
            modelBuilder.HasSequence<int>("SequencialTransacaoCieloSolicitacaoCertificado").StartsAt(1498).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new UfEntregaMap());
            modelBuilder.HasSequence<int>("SequencialUfEntrega").StartsAt(28).IncrementsBy(1);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
