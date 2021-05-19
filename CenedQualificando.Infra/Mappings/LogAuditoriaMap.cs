using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Infra.Mappings
{
    public class LogAuditoriaMap : IEntityTypeConfiguration<LogAuditoria>
    {
        public void Configure(EntityTypeBuilder<LogAuditoria> builder)
        {
            builder.HasKey(e => e.IdLogAuditoria)
                    .HasName("PK_Penitenciario.LogAuditoria");

            builder.Property(c => c.IdLogAuditoria)
                .HasDefaultValueSql("NEXT VALUE FOR SequencialLogAuditoria");

            builder.ToTable("LogAuditoria", "Penitenciario");

            builder.Property(e => e.DataOperacao).HasColumnType("datetime");

            builder.Property(e => e.EnderecoIp).HasColumnName("EnderecoIP");
        }
    }
}
