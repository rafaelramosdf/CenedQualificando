using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Infra.Mappings
{
    public class TransacaoMap : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.HasKey(e => e.IdTransacao)
                    .HasName("PK_Penitenciario.Transacao");

            builder.Property(c => c.IdTransacao)
               .HasDefaultValueSql("NEXT VALUE FOR SequencialTransacao");

            builder.ToTable("Transacao", "Penitenciario");

            builder.Property(e => e.Data).HasColumnType("datetime");

            builder.Property(e => e.DataUltimaSituacao).HasColumnType("datetime");

            builder.Property(e => e.Uf).HasColumnName("UF");

            builder.Property(e => e.ValorTotal).HasColumnType("decimal(18, 2)");
        }
    }
}
