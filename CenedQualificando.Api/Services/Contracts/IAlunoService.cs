using System.Collections.Generic;
using System.Threading.Tasks;
using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Utils;

namespace CenedQualificando.Api.Services.Contracts
{
    public interface IAlunoService : IBaseService<Aluno, AlunoDto>
    {
        Task<IEnumerable<Aluno>> BuscarAlunosPorId(int[] idAlunos);
        IEnumerable<SelectResult> ObterComboSelecao(string pesquisa, int quantidade = 50);
    }
}
