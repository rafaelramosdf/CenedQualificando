using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using System.Collections.Generic;
using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Domain.Interfaces.Services
{
    public interface IPenitenciariaService : IBaseService<Penitenciaria, PenitenciariaViewModel, PenitenciariaFilter>
    {
        IEnumerable<SelectResult> ObterComboSelecao(string pesquisa, int quantidade = 10, int selecionado = 0);
    }
}
