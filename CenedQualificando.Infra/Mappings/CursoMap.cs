using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models;

namespace CenedQualificando.Infra.Mappings
{
    public class CursoMap : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.HasKey(e => e.IdCurso)
                    .HasName("PK_Penitenciario.Curso");

            builder.Property(c => c.IdCurso)
                .HasDefaultValueSql("NEXT VALUE FOR SequencialCurso");

            builder.ToTable("Curso", "Penitenciario");
            
            builder.Property(e => e.Codigo).IsRequired();

            builder.Property(e => e.Nome).IsRequired();

            builder.Property(e => e.Taxa).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.Valor).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.ValorTotal).HasColumnType("decimal(18, 2)");
        }
    }
}
