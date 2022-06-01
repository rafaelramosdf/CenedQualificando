using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;

namespace CenedQualificando.Domain.Interfaces.Services
{
    public interface IPermissaoService : IBaseService<Permissao, PermissaoViewModel, PermissaoFilter>
    {
        void Attach(Permissao obj);
    }
}
