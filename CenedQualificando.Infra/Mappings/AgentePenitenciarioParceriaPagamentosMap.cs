using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Infra.Mappings
{
    public class AgentePenitenciarioParceriaPagamentosMap : IEntityTypeConfiguration<AgentePenitenciarioParceriaPagamentos>
    {
        public void Configure(EntityTypeBuilder<AgentePenitenciarioParceriaPagamentos> builder)
        {
            builder.HasKey(e => e.IdAgentePenitenciarioParceriaPagamentos)
                    .HasName("PK_Penitenciario.AgentePenitenciarioParceriaPagamentos");

            builder.Property(c => c.IdAgentePenitenciarioParceriaPagamentos)
                .HasDefaultValueSql("NEXT VALUE FOR SequencialAgentePenitenciarioParceriaPagamentos");

            builder.ToTable("AgentePenitenciarioParceriaPagamentos", "Penitenciario");

            builder.Property(e => e.DataPagamento).HasColumnType("datetime");

            builder.Property(e => e.PeriodoFim).HasColumnType("datetime");

            builder.Property(e => e.PeriodoInicio).HasColumnType("datetime");

            builder.Property(e => e.RecebimentoConfirmado).HasColumnType("datetime");

            builder.Property(e => e.ValorPago).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.ValorPeriodo).HasColumnType("decimal(18, 2)");
        }
    }
}
