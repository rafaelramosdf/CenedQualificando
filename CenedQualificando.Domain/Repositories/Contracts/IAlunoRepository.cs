using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Domain.Repositories.Contracts
{
    public interface IAlunoRepository : IBaseRepository<Aluno>
    {
        Task<IEnumerable<Aluno>> BuscarAlunosPorId(int[] idAlunos);
    }
}
