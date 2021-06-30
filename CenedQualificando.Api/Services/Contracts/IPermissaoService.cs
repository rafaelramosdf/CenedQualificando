using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Api.Services.Contracts
{
    public interface IPermissaoService : IBaseService<Permissao, PermissaoDto>
    {
        void Attach(Permissao obj);
    }
}
