using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Utils;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.RefitApiServices
{
    public interface IPermissaoApiService
    {
        [Post("/permissoes/filtros")]
        Task<DataTableModel<PermissaoDto>> Filtrar([Body] DataTableModel<PermissaoDto> dataTableModel);
    }
}
