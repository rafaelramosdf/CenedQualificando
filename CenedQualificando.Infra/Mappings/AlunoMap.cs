using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Infra.Mappings
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(e => e.IdAluno)
                    .HasName("PK_Penitenciario.Aluno");

            builder.Property(c => c.IdAluno)
                .HasDefaultValueSql("NEXT VALUE FOR SequencialAluno");

            builder.ToTable("Aluno", "Penitenciario");

            builder.HasIndex(e => e.IdPenitenciaria)
                .HasDatabaseName("IX_IdPenitenciaria");

            builder.Property(e => e.ConfirmarSenha).IsRequired();

            builder.Property(e => e.Cpf).IsRequired();

            builder.Property(e => e.DataNascimento).HasColumnType("datetime");

            builder.Property(e => e.Nome).IsRequired();

            builder.Property(e => e.NomePreposto).IsRequired();

            builder.Property(e => e.Senha).IsRequired();

            builder.HasOne(d => d.IdPenitenciariaNavigation)
                .WithMany(p => p.Aluno)
                .HasForeignKey(d => d.IdPenitenciaria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Penitenciario.Aluno_Penitenciario.Penitenciaria_IdPenitenciaria");
        }
    }
}
