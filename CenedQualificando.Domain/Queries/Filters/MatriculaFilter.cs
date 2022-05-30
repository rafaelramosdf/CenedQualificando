using CenedQualificando.Domain.Models.Enumerations.Filters;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Queries.Filters.Base;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models.Filters
{
    public class MatriculaFilter : Filter
    {
        public MatriculaFilter()
        {
        }
        public MatriculaFilter(MatriculaFilterEnum tipoFiltroPersonalizado)
        {
            TipoFiltroPersonalizado = tipoFiltroPersonalizado;
        }

        public int? IdAluno { get; set; }
        public int? IdPenitenciaria { get; set; }
        public IEnumerable<int> IdMatriculas { get; set; } = new List<int>();
        public MatriculaFilterEnum TipoFiltroPersonalizado { get; set; } = MatriculaFilterEnum.Null;
        public IEnumerable<int> StatusCurso { get; set; } = new List<int>();
        public DateTimeRange PeriodoDataMatricula { get; set; } = new DateTimeRange();
        public DateTimeRange PeriodoDataPiso { get; set; } = new DateTimeRange();
        public DateTimeRange PeriodoDataCertificadoExpedido { get; set; } = new DateTimeRange();
        public DateTimeRange PeriodoDataProvaRecebida { get; set; } = new DateTimeRange();
    }
}
