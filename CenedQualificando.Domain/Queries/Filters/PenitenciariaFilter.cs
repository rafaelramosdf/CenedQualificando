using CenedQualificando.Domain.Models.Enumerations;
using CenedQualificando.Domain.Queries.Filters.Base;

namespace CenedQualificando.Domain.Models.Filters
{
    public class PenitenciariaFilter : Filter
    {
        public UfEnum Uf { get; set; } = UfEnum.Null;
    }
}