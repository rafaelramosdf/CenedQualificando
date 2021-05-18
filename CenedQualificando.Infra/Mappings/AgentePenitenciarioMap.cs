using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models;

namespace CenedQualificando.Infra.Mappings
{
    public class AgentePenitenciarioMap : IEntityTypeConfiguration<AgentePenitenciario>
    {
        public void Configure(EntityTypeBuilder<AgentePenitenciario> builder)
        {
            builder.HasKey(e => e.IdAgentePenitenciario)
                    .HasName("PK_Penitenciario.AgentePenitenciario");

            builder.Property(c => c.IdAgentePenitenciario)
                .HasDefaultValueSql("NEXT VALUE FOR SequencialAgentePenitenciario");

            builder.ToTable("AgentePenitenciario", "Penitenciario");

            builder.HasIndex(e => e.IdGrupoDePermissao)
                .HasDatabaseName("IX_IdGrupoDePermissao");

            builder.HasIndex(e => e.IdPenitenciaria)
                .HasDatabaseName("IX_IdPenitenciaria");
            
            builder.Property(e => e.ConfirmarSenha).IsRequired();

            builder.Property(e => e.DataExpiracaoSenha).HasColumnType("datetime");

            builder.Property(e => e.DataInicioParceria).HasColumnType("datetime");

            builder.Property(e => e.Email).IsRequired();

            builder.Property(e => e.Login).IsRequired();

            builder.Property(e => e.Nome).IsRequired();

            builder.Property(e => e.Senha).IsRequired();

            builder.HasOne(d => d.IdGrupoDePermissaoNavigation)
                .WithMany(p => p.AgentePenitenciario)
                .HasForeignKey(d => d.IdGrupoDePermissao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Penitenciario.AgentePenitenciario_Penitenciario.GrupoDePermissao_IdGrupoDePermissao");

            builder.HasOne(d => d.IdPenitenciariaNavigation)
                .WithMany(p => p.AgentePenitenciario)
                .HasForeignKey(d => d.IdPenitenciaria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Penitenciario.AgentePenitenciario_Penitenciario.Penitenciaria_IdPenitenciaria");
        }
    }
}
