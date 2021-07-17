using System.Collections.Generic;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Interfaces.Services
{
    public interface IGrupoDePermissaoService : IBaseService<GrupoDePermissao, GrupoDePermissaoDto>
    {
        IEnumerable<int> GetIdPermissoes(int idGrupoPermissao);
    }
}
