using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Infra.Mappings
{
    public class SolicitacaoAutorizacaoMatriculaCursosMap : IEntityTypeConfiguration<SolicitacaoAutorizacaoMatriculaCursos>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoAutorizacaoMatriculaCursos> builder)
        {
            builder.HasKey(e => e.IdSolicitacaoAutorizacaoMatriculaCursos)
                    .HasName("PK_Penitenciario.SolicitacaoAutorizacaoMatriculaCursos");

            builder.Property(c => c.IdSolicitacaoAutorizacaoMatriculaCursos)
               .HasDefaultValueSql("NEXT VALUE FOR SequencialSolicitacaoAutorizacaoMatriculaCursos");

            builder.ToTable("SolicitacaoAutorizacaoMatriculaCursos", "Penitenciario");

            builder.Property(e => e.DataUltimaSituacao).HasColumnType("datetime");
        }
    }
}
