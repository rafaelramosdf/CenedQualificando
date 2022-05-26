using System.Collections.Generic;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;

namespace CenedQualificando.Domain.Interfaces.Services
{
    public interface IGrupoDePermissaoService : IBaseService<GrupoDePermissao, GrupoDePermissaoDto, GrupoDePermissaoFilter>
    {
        IEnumerable<int> GetIdPermissoes(int idGrupoPermissao);
    }
}
