using System.Collections.Generic;
using System.Threading.Tasks;
using CenedQualificando.Domain.Interfaces.Repository.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Interfaces.Repository
{
    public interface IGrupoDePermissaoRepository : IBaseRepository<GrupoDePermissao>
    {
        Task<IEnumerable<Permissao>> GetPermissoesAsync(int idGrupoPermissao);
    }
}
