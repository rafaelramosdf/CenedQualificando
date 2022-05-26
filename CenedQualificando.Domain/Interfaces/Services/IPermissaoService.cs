using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;

namespace CenedQualificando.Domain.Interfaces.Services
{
    public interface IPermissaoService : IBaseService<Permissao, PermissaoDto, PermissaoFilter>
    {
        void Attach(Permissao obj);
    }
}
