using CenedQualificando.Domain.Interfaces.Repository.Base;
using CenedQualificando.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Domain.Interfaces.Repository
{
    public interface IProvaRepository : IBaseRepository<Prova>
    {
        Task<IEnumerable<Prova>> BuscarProvasPorIdMatriculas(int[] idMatriculas);
    }
}
