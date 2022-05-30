using CenedQualificando.Domain.Queries.Filters.Base;

namespace CenedQualificando.Domain.Models.Filters
{
    public class ProvaFilter : Filter
    {
        public int[] IdMatriculas { get; set; }
    }
}