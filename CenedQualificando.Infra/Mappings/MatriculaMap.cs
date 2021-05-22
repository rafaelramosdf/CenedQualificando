using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Infra.Mappings
{
    public class MatriculaMap : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            builder.HasKey(e => e.IdMatricula)
                    .HasName("PK_Penitenciario.Matricula");

            builder.Property(c => c.IdMatricula)
               .HasDefaultValueSql("NEXT VALUE FOR SequencialMatricula");

            builder.ToTable("Matricula", "Penitenciario");

            builder.HasIndex(e => e.IdAluno)
                .HasDatabaseName("IX_IdAluno");

            builder.HasIndex(e => e.IdCurso)
                .HasDatabaseName("IX_IdCurso");

            builder.HasIndex(e => e.IdPenitenciaria)
                .HasDatabaseName("IX_IdPenitenciaria");

            builder.HasIndex(e => e.IdUsuario)
                .HasDatabaseName("IX_IdUsuario");

            builder.Property(e => e.CertificadoEnviado).HasColumnType("datetime");

            builder.Property(e => e.CertificadoExpedido).HasColumnType("datetime");

            builder.Property(e => e.DataMatricula).HasColumnType("datetime");

            builder.Property(e => e.DataPagamento).HasColumnType("datetime");

            builder.Property(e => e.DataPiso).HasColumnType("datetime");

            builder.Property(e => e.DataPostagem).HasColumnType("datetime");

            builder.Property(e => e.DataPrescricao).HasColumnType("datetime");

            builder.Property(e => e.DataStatusCurso).HasColumnType("datetime");

            builder.Property(e => e.InicioCurso).HasColumnType("datetime");

            builder.Property(e => e.TerminoCurso).HasColumnType("datetime");

            builder.Property(e => e.ValorTotal).HasColumnType("decimal(18, 2)");

            builder.HasOne(d => d.Aluno)
                .WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.IdAluno)
                .HasConstraintName("FK_Penitenciario.Matricula_Penitenciario.Aluno_IdAluno");

            builder.HasOne(d => d.Curso)
                .WithMany(p => p.Matricula)
                .HasForeignKey(d => d.IdCurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Penitenciario.Matricula_Penitenciario.Curso_IdCurso");

            builder.HasOne(d => d.Penitenciaria)
                .WithMany(p => p.Matricula)
                .HasForeignKey(d => d.IdPenitenciaria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Penitenciario.Matricula_Penitenciario.Penitenciaria_IdPenitenciaria");

            builder.HasOne(d => d.Usuario)
                .WithMany(p => p.Matricula)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Penitenciario.Matricula_Penitenciario.Usuario_IdUsuario");
        }
    }
}
