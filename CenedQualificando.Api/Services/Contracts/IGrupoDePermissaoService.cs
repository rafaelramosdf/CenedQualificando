using System.Collections.Generic;
using System.Threading.Tasks;
using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Api.Services.Contracts
{
    public interface IGrupoDePermissaoService : IBaseService<GrupoDePermissao, GrupoDePermissaoDto>
    {
        Task<IEnumerable<PermissaoDto>> GetPermissoesAsync(int idGrupoPermissao);
    }
}
