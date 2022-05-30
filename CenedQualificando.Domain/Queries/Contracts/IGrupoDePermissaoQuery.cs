using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Queries.Base;

namespace CenedQualificando.Domain.Queries.Contracts
{
    public interface IGrupoDePermissaoQuery : IBaseQuery<GrupoDePermissao, GrupoDePermissaoFilter>
    {
    }
}
