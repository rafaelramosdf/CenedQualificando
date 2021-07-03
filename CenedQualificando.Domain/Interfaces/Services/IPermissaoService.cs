using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Interfaces.Services
{
    public interface IPermissaoService : IBaseService<Permissao, PermissaoDto>
    {
        void Attach(Permissao obj);
    }
}
