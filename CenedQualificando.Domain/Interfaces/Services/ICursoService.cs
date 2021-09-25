using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Domain.Interfaces.Services
{
    public interface ICursoService : IBaseService<Curso, CursoDto>
    {
        IEnumerable<SelectResult> ObterComboSelecao(string pesquisa, int quantidade = 50);
    }
}
