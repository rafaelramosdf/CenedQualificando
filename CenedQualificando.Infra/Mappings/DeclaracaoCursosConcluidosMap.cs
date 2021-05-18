using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models;

namespace CenedQualificando.Infra.Mappings
{
    public class DeclaracaoCursosConcluidosMap : IEntityTypeConfiguration<DeclaracaoCursosConcluidos>
    {
        public void Configure(EntityTypeBuilder<DeclaracaoCursosConcluidos> builder)
        {
            builder.HasKey(e => e.IdDeclaracaoCursosConcluidos)
                    .HasName("PK_Penitenciario.DeclaracaoCursosConcluidos");

            builder.Property(c => c.IdDeclaracaoCursosConcluidos)
                .HasDefaultValueSql("NEXT VALUE FOR SequencialDeclaracaoCursosConcluidos");

            builder.ToTable("DeclaracaoCursosConcluidos", "Penitenciario");

            builder.Property(e => e.DataGeracao).HasColumnType("datetime");
        }
    }
}
