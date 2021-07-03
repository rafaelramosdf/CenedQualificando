using System.Collections.Generic;
using System.Threading.Tasks;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Interfaces.Services
{
    public interface IGrupoDePermissaoService : IBaseService<GrupoDePermissao, GrupoDePermissaoDto>
    {
        Task<IEnumerable<PermissaoDto>> GetPermissoesAsync(int idGrupoPermissao);
    }
}
