using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using System.Collections.Generic;
using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Domain.Interfaces.Services
{
    public interface ICursoService : IBaseService<Curso, CursoViewModel, CursoFilter>
    {
        IEnumerable<SelectResult> ObterComboSelecao(string pesquisa, int quantidade = 50);
    }
}
