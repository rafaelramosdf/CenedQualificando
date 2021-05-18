using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models;

namespace CenedQualificando.Infra.Mappings
{
    public class AgentePenitenciarioParceriaMap : IEntityTypeConfiguration<AgentePenitenciarioParceria>
    {
        public void Configure(EntityTypeBuilder<AgentePenitenciarioParceria> builder)
        {
            builder.HasKey(e => e.IdAgentePenitenciarioParceria)
                    .HasName("PK_Penitenciario.AgentePenitenciarioParceria");

            builder.Property(c => c.IdAgentePenitenciarioParceria)
                .HasDefaultValueSql("NEXT VALUE FOR SequencialAgentePenitenciarioParceria");

            builder.ToTable("AgentePenitenciarioParceria", "Penitenciario");
            
            builder.Property(e => e.DataInicioParceria).HasColumnType("datetime");
        }
    }
}
