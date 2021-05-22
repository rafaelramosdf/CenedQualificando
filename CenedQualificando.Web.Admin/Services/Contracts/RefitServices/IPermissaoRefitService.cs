using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.Contracts.RefitServices
{
    public interface IPermissaoRefitService
    {
        [Post("/permissoes/filtros")]
        Task<DataTableModel<PermissaoDto>> Filtrar([Body] DataTableModel<PermissaoDto> dataTableModel);
    }
}
