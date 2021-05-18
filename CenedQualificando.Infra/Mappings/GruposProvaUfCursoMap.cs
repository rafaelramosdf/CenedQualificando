using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CenedQualificando.Infra.Mappings
{
    public class GruposProvaUfCursoMap : IEntityTypeConfiguration<GruposProvaUfCurso>
    {
        public void Configure(EntityTypeBuilder<GruposProvaUfCurso> builder)
        {
            builder.HasKey(e => new { e.GruposProvaUfIdGruposProvaUf, e.CursoIdCurso })
                    .HasName("PK_Penitenciario.GruposProvaUfCurso");
            
            builder.ToTable("GruposProvaUfCurso", "Penitenciario");

            builder.HasIndex(e => e.CursoIdCurso)
                .HasDatabaseName("IX_Curso_IdCurso");

            builder.HasIndex(e => e.GruposProvaUfIdGruposProvaUf)
                .HasDatabaseName("IX_GruposProvaUf_IdGruposProvaUf");

            builder.Property(e => e.GruposProvaUfIdGruposProvaUf).HasColumnName("GruposProvaUf_IdGruposProvaUf");

            builder.Property(e => e.CursoIdCurso).HasColumnName("Curso_IdCurso");

            builder.HasOne(d => d.CursoIdCursoNavigation)
                .WithMany(p => p.GruposProvaUfCurso)
                .HasForeignKey(d => d.CursoIdCurso)
                .HasConstraintName("FK_Penitenciario.GruposProvaUfCurso_Penitenciario.Curso_Curso_IdCurso");

            builder.HasOne(d => d.GruposProvaUfIdGruposProvaUfNavigation)
                .WithMany(p => p.GruposProvaUfCurso)
                .HasForeignKey(d => d.GruposProvaUfIdGruposProvaUf)
                .HasConstraintName("FK_Penitenciario.GruposProvaUfCurso_Penitenciario.GruposProvaUf_GruposProvaUf_IdGruposProvaUf");
        }
    }
}
