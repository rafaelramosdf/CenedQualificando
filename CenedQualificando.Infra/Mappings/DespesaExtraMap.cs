using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Infra.Mappings
{
    public class DespesaExtraMap : IEntityTypeConfiguration<DespesaExtra>
    {
        public void Configure(EntityTypeBuilder<DespesaExtra> builder)
        {
            builder.HasKey(e => e.IdDespesaExtra)
                    .HasName("PK_Penitenciario.DespesaExtra");

            builder.Property(c => c.IdDespesaExtra)
                .HasDefaultValueSql("NEXT VALUE FOR SequencialDespesaExtra");

            builder.ToTable("DespesaExtra", "Penitenciario");

            builder.HasIndex(e => e.IdMatricula)
                .HasDatabaseName("IX_IdMatricula");

            builder.Property(e => e.Boleto).IsRequired();

            builder.Property(e => e.DataPagamento).HasColumnType("datetime");

            builder.Property(e => e.Tipo).IsRequired();

            builder.Property(e => e.Valor).HasColumnType("decimal(18, 2)");

            builder.HasOne(d => d.IdMatriculaNavigation)
                .WithMany(p => p.DespesaExtra)
                .HasForeignKey(d => d.IdMatricula)
                .HasConstraintName("FK_Penitenciario.DespesaExtra_Penitenciario.Matricula_IdMatricula");
        }
    }
}
