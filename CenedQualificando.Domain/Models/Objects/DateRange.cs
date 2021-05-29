using System;
using CenedQualificando.Domain.Extensions;

namespace CenedQualificando.Domain.Models.Objects
{
    public class DateRange
    {
        private readonly DateTime defaultStart = new DateTime(1800, 1, 1);
        private readonly DateTime defaultEnd = new DateTime(9999, 12, 31);

        private DateTime? _start { get; set; }
        /// <summary>
        /// Sempre retorna uma Data inicial com a primeira Hora do dia
        /// </summary>
        public DateTime? Start
        {
            get { return _start.HasValue ? _start.Value.ToPrimeiraHoraData() : defaultStart; }
            set { _start = value.HasValue ? value.Value.ToPrimeiraHoraData() : defaultStart; }
        }

        private DateTime? _end { get; set; }
        /// <summary>
        /// Sempre retorna uma Data final com a última Hora do dia
        /// </summary>
        public DateTime? End
        {
            get { return _end.HasValue ? _end.Value.ToUltimaHoraData() : defaultEnd; }
            set { _end = value.HasValue ? value.Value.ToUltimaHoraData() : defaultEnd; }
        }

        public bool HasValue => Start != defaultStart || End != defaultEnd;
    }
}
