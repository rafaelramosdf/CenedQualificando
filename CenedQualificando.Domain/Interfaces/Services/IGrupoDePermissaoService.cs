using System.Collections.Generic;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;

namespace CenedQualificando.Domain.Interfaces.Services
{
    public interface IGrupoDePermissaoService : IBaseService<GrupoDePermissao, GrupoDePermissaoViewModel, GrupoDePermissaoFilter>
    {
        IEnumerable<int> GetIdPermissoes(int idGrupoPermissao);
    }
}
