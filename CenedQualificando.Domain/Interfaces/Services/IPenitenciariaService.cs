using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Utils;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Interfaces.Services
{
    public interface IPenitenciariaService : IBaseService<Penitenciaria, PenitenciariaDto>
    {
        IEnumerable<SelectResult> ObterComboSelecao(string pesquisa, int quantidade);
    }
}
