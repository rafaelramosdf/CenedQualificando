using System.Collections.Generic;
using System.Threading.Tasks;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Utils;

namespace CenedQualificando.Domain.Interfaces.Services
{
    public interface IAlunoService : IBaseService<Aluno, AlunoDto>
    {
        Task<IEnumerable<Aluno>> BuscarAlunosPorId(int[] idAlunos);
        IEnumerable<SelectResult> ObterComboSelecao(string pesquisa, int quantidade = 50);
    }
}
