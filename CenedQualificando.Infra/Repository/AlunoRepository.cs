using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Domain.Models;
using CenedQualificando.Infra.Context;
using CenedQualificando.Infra.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Infra.Repository
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(EntityContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Aluno>> BuscarAlunosPorId(int[] idAlunos)
        {
            return null;
            // TODO: Refazer com EntityFramework
            //return await GetAllAsync($@"WHERE Aluno.IdAluno IN ({string.Join(",", idAlunos)})");
        }
    }
}
