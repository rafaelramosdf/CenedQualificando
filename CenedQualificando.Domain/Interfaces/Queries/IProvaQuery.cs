using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;

namespace CenedQualificando.Domain.Interfaces.Queries
{
    public interface IProvaQuery : IBaseQuery<Prova, ProvaFilter>
    {
    }
}
