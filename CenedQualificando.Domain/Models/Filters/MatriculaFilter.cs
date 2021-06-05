using CenedQualificando.Domain.Models.Enumerations.Filters;
using CenedQualificando.Domain.Models.Utils;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models.Filters
{
    public class MatriculaFilter
    {
        public MatriculaFilter()
        {
        }
        public MatriculaFilter(MatriculaFilterEnum tipoFiltroPersonalizado)
        {
            TipoFiltroPersonalizado = tipoFiltroPersonalizado;
        }

        public int IdAluno { get; set; }
        public int IdPenitenciaria { get; set; }
        public IEnumerable<int> IdMatriculas { get; set; } = new List<int>();
        public MatriculaFilterEnum TipoFiltroPersonalizado { get; set; }
        public IEnumerable<int> StatusCurso { get; set; } = new List<int>();
        public PeriodoData PeriodoDataMatricula { get; set; } = new PeriodoData();
        public PeriodoData PeriodoDataPiso { get; set; } = new PeriodoData();
        public PeriodoData PeriodoDataCertificadoExpedido { get; set; } = new PeriodoData();
        public PeriodoData PeriodoDataProvaRecebida { get; set; } = new PeriodoData();
    }
}
