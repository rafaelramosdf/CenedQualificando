using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Infra.Mappings
{
    public class SolicitacaoAutorizacaoMatriculaMap : IEntityTypeConfiguration<SolicitacaoAutorizacaoMatricula>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoAutorizacaoMatricula> builder)
        {
            builder.HasKey(e => e.IdSolicitacaoAutorizacaoMatricula)
                    .HasName("PK_Penitenciario.SolicitacaoAutorizacaoMatricula");

            builder.Property(c => c.IdSolicitacaoAutorizacaoMatricula)
               .HasDefaultValueSql("NEXT VALUE FOR SequencialSolicitacaoAutorizacaoMatricula");

            builder.ToTable("SolicitacaoAutorizacaoMatricula", "Penitenciario");

            builder.Property(e => e.Celular).IsRequired();

            builder.Property(e => e.CpfSolicitante).IsRequired();

            builder.Property(e => e.DataHora).HasColumnType("datetime");

            builder.Property(e => e.EnderecoIp).HasColumnName("EnderecoIP");

            builder.Property(e => e.ListaDeCursos).IsRequired();

            builder.Property(e => e.NomeInterno).IsRequired();

            builder.Property(e => e.NomeSolicitante).IsRequired();
        }
    }
}
