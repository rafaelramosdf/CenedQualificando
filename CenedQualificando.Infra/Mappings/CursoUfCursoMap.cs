using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models;

namespace CenedQualificando.Infra.Mappings
{
    public class CursoUfCursoMap : IEntityTypeConfiguration<CursoUfCurso>
    {
        public void Configure(EntityTypeBuilder<CursoUfCurso> entity)
        {
            entity.HasKey(e => new { e.CursoUfIdCursoUf, e.CursoIdCurso })
                    .HasName("PK_Penitenciario.CursoUfCurso");
            
            entity.ToTable("CursoUfCurso", "Penitenciario");

            entity.HasIndex(e => e.CursoIdCurso)
                .HasDatabaseName("IX_Curso_IdCurso");

            entity.HasIndex(e => e.CursoUfIdCursoUf)
                .HasDatabaseName("IX_CursoUf_IdCursoUf");

            entity.Property(e => e.CursoUfIdCursoUf).HasColumnName("CursoUf_IdCursoUf");

            entity.Property(e => e.CursoIdCurso).HasColumnName("Curso_IdCurso");

            entity.HasOne(d => d.CursoIdCursoNavigation)
                .WithMany(p => p.CursoUfCurso)
                .HasForeignKey(d => d.CursoIdCurso)
                .HasConstraintName("FK_Penitenciario.CursoUfCurso_Penitenciario.Curso_Curso_IdCurso");

            entity.HasOne(d => d.CursoUfIdCursoUfNavigation)
                .WithMany(p => p.CursoUfCurso)
                .HasForeignKey(d => d.CursoUfIdCursoUf)
                .HasConstraintName("FK_Penitenciario.CursoUfCurso_Penitenciario.CursoUf_CursoUf_IdCursoUf");
        }
    }
}
