using System;
using CenedQualificando.Domain.Extensions;

namespace CenedQualificando.Domain.Models.Utils
{
    public class PeriodoData
    {
        private readonly DateTime inicioMinimo = new DateTime(1800, 1, 1);
        private readonly DateTime finalMaximo = new DateTime(9999, 12, 31);

        private DateTime? _inicio { get; set; }
        /// <summary>
        /// Sempre retorna uma Data inicial com a primeira Hora do dia
        /// </summary>
        public DateTime? Inicio
        {
            get { return _inicio.HasValue ? _inicio.Value.ToPrimeiraHoraData() : inicioMinimo; }
            set { _inicio = value.HasValue ? value.Value.ToPrimeiraHoraData() : inicioMinimo; }
        }

        private DateTime? _final { get; set; }
        /// <summary>
        /// Sempre retorna uma Data final com a última Hora do dia
        /// </summary>
        public DateTime? Final
        {
            get { return _final.HasValue ? _final.Value.ToUltimaHoraData() : finalMaximo; }
            set { _final = value.HasValue ? value.Value.ToUltimaHoraData() : finalMaximo; }
        }

        public bool HasValue => Inicio != inicioMinimo || Final != finalMaximo;
    }
}
