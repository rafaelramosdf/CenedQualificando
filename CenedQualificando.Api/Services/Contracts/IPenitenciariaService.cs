using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Utils;
using System.Collections.Generic;

namespace CenedQualificando.Api.Services.Contracts
{
    public interface IPenitenciariaService : IBaseService<Penitenciaria, PenitenciariaDto>
    {
        IEnumerable<SelectResult> ObterComboSelecao(string pesquisa, int quantidade = 10, int selecionado = 0);
    }
}
