using CenedQualificando.Domain.Models.Enumerations.Filters;
using CenedQualificando.Domain.Models.Objects;
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

        public int IdPenitenciaria { get; set; }
        public MatriculaFilterEnum TipoFiltroPersonalizado { get; set; }
        public IEnumerable<int> StatusCurso { get; set; } = new List<int>();
        public DateRange PeriodoDataMatricula { get; set; } = new DateRange();
        public DateRange PeriodoDataPiso { get; set; } = new DateRange();
    }
}
