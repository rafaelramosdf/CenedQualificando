using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models;

namespace CenedQualificando.Infra.Mappings
{
    public class SolicitacaoCertificadoMap : IEntityTypeConfiguration<SolicitacaoCertificado>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoCertificado> builder)
        {
            builder.HasKey(e => e.IdSolicitacaoCertificado)
                    .HasName("PK_Penitenciario.SolicitacaoCertificado");

            builder.Property(c => c.IdSolicitacaoCertificado)
               .HasDefaultValueSql("NEXT VALUE FOR SequencialSolicitacaoCertificado");

            builder.ToTable("SolicitacaoCertificado", "Penitenciario");

            builder.HasIndex(e => e.IdMatricula)
                .HasDatabaseName("IX_IdMatricula");

            builder.Property(e => e.CpfSolicitante).HasMaxLength(20);

            builder.Property(e => e.Data).HasColumnType("datetime");

            builder.Property(e => e.EnderecoBairro).HasMaxLength(250);

            builder.Property(e => e.EnderecoCep).HasMaxLength(20);

            builder.Property(e => e.EnderecoCidade).HasMaxLength(250);

            builder.Property(e => e.EnderecoComplemento).HasMaxLength(250);

            builder.Property(e => e.EnderecoLogradouro).HasMaxLength(250);

            builder.Property(e => e.EnderecoNumero).HasMaxLength(20);

            builder.Property(e => e.NomeSolicitante).HasMaxLength(250);

            builder.Property(e => e.Telefone).HasMaxLength(20);

            builder.Property(e => e.ValorFrete).HasColumnType("decimal(18, 2)");

            builder.HasOne(d => d.IdMatriculaNavigation)
                .WithMany(p => p.SolicitacaoCertificado)
                .HasForeignKey(d => d.IdMatricula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Penitenciario.SolicitacaoCertificado_Penitenciario.Matricula_IdMatricula");
        }
    }
}
