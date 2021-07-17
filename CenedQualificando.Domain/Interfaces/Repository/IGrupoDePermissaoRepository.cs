using System.Collections.Generic;
using CenedQualificando.Domain.Interfaces.Repository.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Interfaces.Repository
{
    public interface IGrupoDePermissaoRepository : IBaseRepository<GrupoDePermissao>
    {
        IEnumerable<int> GetIdPermissoes(int idGrupoPermissao);
    }
}
