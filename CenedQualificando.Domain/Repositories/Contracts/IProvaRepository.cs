using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Domain.Repositories.Contracts
{
    public interface IProvaRepository : IBaseRepository<Prova>
    {
        Task<IEnumerable<Prova>> BuscarProvasPorIdMatriculas(int[] idMatriculas);
    }
}
