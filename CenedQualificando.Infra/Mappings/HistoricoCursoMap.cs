using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models;

namespace CenedQualificando.Infra.Mappings
{
    public class HistoricoCursoMap : IEntityTypeConfiguration<HistoricoCurso>
    {
        public void Configure(EntityTypeBuilder<HistoricoCurso> builder)
        {
            builder.HasKey(e => e.IdHistoricoCurso)
                    .HasName("PK_Penitenciario.HistoricoCurso");

            builder.Property(c => c.IdHistoricoCurso)
                .HasDefaultValueSql("NEXT VALUE FOR SequencialHistoricoCurso");

            builder.ToTable("HistoricoCurso", "Penitenciario");

            builder.HasIndex(e => e.IdMatricula)
                .HasDatabaseName("IX_IdMatricula");

            builder.HasIndex(e => e.IdTabelaHistoricoCurso)
                .HasDatabaseName("IX_IdTabelaHistoricoCurso");
            
            builder.Property(e => e.DataHora).HasColumnType("datetime");

            builder.HasOne(d => d.IdMatriculaNavigation)
                .WithMany(p => p.HistoricoCurso)
                .HasForeignKey(d => d.IdMatricula)
                .HasConstraintName("FK_Penitenciario.HistoricoCurso_Penitenciario.Matricula_IdMatricula");

            builder.HasOne(d => d.IdTabelaHistoricoCursoNavigation)
                .WithMany(p => p.HistoricoCurso)
                .HasForeignKey(d => d.IdTabelaHistoricoCurso)
                .HasConstraintName("FK_Penitenciario.HistoricoCurso_Penitenciario.TabelaHistoricoCurso_IdTabelaHistoricoCurso");
        }
    }
}
