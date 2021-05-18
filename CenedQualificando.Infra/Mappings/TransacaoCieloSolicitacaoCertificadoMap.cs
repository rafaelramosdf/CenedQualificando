using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models;

namespace CenedQualificando.Infra.Mappings
{
    public class TransacaoCieloSolicitacaoCertificadoMap : IEntityTypeConfiguration<TransacaoCieloSolicitacaoCertificado>
    {
        public void Configure(EntityTypeBuilder<TransacaoCieloSolicitacaoCertificado> builder)
        {
            builder.HasKey(e => e.IdTransacaoCieloSolicitacaoCertificado)
                    .HasName("PK_Penitenciario.TransacaoCieloSolicitacaoCertificado");

            builder.Property(c => c.IdTransacaoCieloSolicitacaoCertificado)
               .HasDefaultValueSql("NEXT VALUE FOR SequencialTransacaoCieloSolicitacaoCertificado");

            builder.ToTable("TransacaoCieloSolicitacaoCertificado", "Penitenciario");

            builder.Property(e => e.Data).HasColumnType("datetime");

            builder.Property(e => e.DataUltimaSituacao).HasColumnType("datetime");

            builder.Property(e => e.ValorTotal).HasColumnType("decimal(18, 2)");
        }
    }
}
