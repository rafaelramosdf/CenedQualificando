using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Infra.Mappings
{
    public class ProvaMap : IEntityTypeConfiguration<Prova>
    {
        public void Configure(EntityTypeBuilder<Prova> builder)
        {
            builder.HasKey(e => e.IdProva)
                    .HasName("PK_Penitenciario.Prova");

            builder.Property(c => c.IdProva)
               .HasDefaultValueSql("NEXT VALUE FOR SequencialProva");

            builder.ToTable("Prova", "Penitenciario");

            builder.HasIndex(e => e.IdMatricula)
                .HasDatabaseName("IX_IdMatricula");

            builder.Property(e => e.DataAgendadaProva).HasColumnType("datetime");

            builder.Property(e => e.DataEnvioProva).HasColumnType("datetime");

            builder.Property(e => e.DataRecebidaProva).HasColumnType("datetime");

            builder.Property(e => e.Nota).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.TipoProva).IsRequired();

            builder.HasOne(d => d.IdMatriculaNavigation)
                .WithMany(p => p.Provas)
                .HasForeignKey(d => d.IdMatricula)
                .HasConstraintName("FK_Penitenciario.Prova_Penitenciario.Matricula_IdMatricula");
        }
    }
}
