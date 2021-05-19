using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Infra.Mappings
{
    public class EstoqueMaterialMap : IEntityTypeConfiguration<EstoqueMaterial>
    {
        public void Configure(EntityTypeBuilder<EstoqueMaterial> builder)
        {
            builder.HasKey(e => e.IdEstoqueMaterial)
                    .HasName("PK_Penitenciario.EstoqueMaterial");

            builder.Property(c => c.IdEstoqueMaterial)
                .HasDefaultValueSql("NEXT VALUE FOR SequencialEstoqueMaterial");

            builder.ToTable("EstoqueMaterial", "Penitenciario");

            builder.HasIndex(e => e.IdCurso)
                .HasDatabaseName("IX_IdCurso");

            builder.HasOne(d => d.IdCursoNavigation)
                .WithMany(p => p.EstoqueMaterial)
                .HasForeignKey(d => d.IdCurso)
                .HasConstraintName("FK_Penitenciario.EstoqueMaterial_Penitenciario.Curso_IdCurso");
        }
    }
}
