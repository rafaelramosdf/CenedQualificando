using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models;

namespace CenedQualificando.Infra.Mappings
{
    public class ImpressaoCertificadoMap : IEntityTypeConfiguration<ImpressaoCertificado>
    {
        public void Configure(EntityTypeBuilder<ImpressaoCertificado> builder)
        {
            builder.HasKey(e => e.IdImpressaoCertificado)
                    .HasName("PK_Penitenciario.ImpressaoCertificado");

            builder.Property(c => c.IdImpressaoCertificado)
                .HasDefaultValueSql("NEXT VALUE FOR SequencialImpressaoCertificado");

            builder.ToTable("ImpressaoCertificado", "Penitenciario");

            builder.HasIndex(e => e.IdCurso)
                .HasDatabaseName("IX_IdCurso");
            
            builder.HasOne(d => d.IdCursoNavigation)
                .WithMany(p => p.ImpressaoCertificado)
                .HasForeignKey(d => d.IdCurso)
                .HasConstraintName("FK_Penitenciario.ImpressaoCertificado_Penitenciario.Curso_IdCurso");
        }
    }
}
