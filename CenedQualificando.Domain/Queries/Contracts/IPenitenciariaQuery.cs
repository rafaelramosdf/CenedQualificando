using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Queries.Base;
using System.Linq;

namespace CenedQualificando.Domain.Queries.Contracts
{
    public interface IPenitenciariaQuery : IBaseQuery<Penitenciaria, PenitenciariaFilter>
    {
        IQueryable<Penitenciaria> FiltrarPenitenciarias(PenitenciariaFilter filtro, IQueryable<Penitenciaria> queryList);
    }
}
