using System;
using CenedQualificando.Domain.Extensions;

namespace CenedQualificando.Domain.Models.Utils
{
    public class PeriodoData
    {
        private DateTime? _inicio { get; set; }
        /// <summary>
        /// Sempre retorna uma Data inicial com a primeira Hora do dia
        /// </summary>
        public DateTime? Inicio
        {
            get { return _inicio.HasValue ? _inicio.Value.ToPrimeiraHoraData() : null; }
            set { _inicio = value.HasValue ? value.Value.ToPrimeiraHoraData() : null; }
        }

        private DateTime? _final { get; set; }
        /// <summary>
        /// Sempre retorna uma Data final com a última Hora do dia
        /// </summary>
        public DateTime? Final
        {
            get { return _final.HasValue ? _final.Value.ToUltimaHoraData() : null; }
            set { _final = value.HasValue ? value.Value.ToUltimaHoraData() : null; }
        }
    }
}
