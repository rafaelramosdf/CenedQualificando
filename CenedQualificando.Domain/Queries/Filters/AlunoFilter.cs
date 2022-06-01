using CenedQualificando.Domain.Queries.Filters.Base;

namespace CenedQualificando.Domain.Models.Filters
{
    public class AlunoFilter : Filter
    {
        public int IdPenitenciaria { get; set; } = 0;
        public string Cpf { get; set; } = string.Empty;
    }
}