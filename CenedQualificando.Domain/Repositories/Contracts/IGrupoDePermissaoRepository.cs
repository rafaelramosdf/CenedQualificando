using System.Collections.Generic;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Repositories.Base;

namespace CenedQualificando.Domain.Repositories.Contracts
{
    public interface IGrupoDePermissaoRepository : IBaseRepository<GrupoDePermissao>
    {
        IEnumerable<int> GetIdPermissoes(int idGrupoPermissao);
    }
}
