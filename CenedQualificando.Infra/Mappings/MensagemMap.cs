using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Infra.Mappings
{
    public class MensagemMap : IEntityTypeConfiguration<Mensagem>
    {
        public void Configure(EntityTypeBuilder<Mensagem> builder)
        {
            builder.HasKey(e => e.IdMensagem)
                    .HasName("PK_Penitenciario.Mensagem");

            builder.Property(c => c.IdMensagem)
               .HasDefaultValueSql("NEXT VALUE FOR SequencialMensagem");

            builder.ToTable("Mensagem", "Penitenciario");

            builder.HasIndex(e => e.IdAluno)
                .HasDatabaseName("IX_IdAluno");

            builder.Property(e => e.DataEnvio).HasColumnType("datetime");

            builder.Property(e => e.Texto).IsRequired();

            builder.Property(e => e.Titulo).IsRequired();

            builder.HasOne(d => d.IdAlunoNavigation)
                .WithMany(p => p.Mensagens)
                .HasForeignKey(d => d.IdAluno)
                .HasConstraintName("FK_Penitenciario.Mensagem_Penitenciario.Aluno_IdAluno");
        }
    }
}
