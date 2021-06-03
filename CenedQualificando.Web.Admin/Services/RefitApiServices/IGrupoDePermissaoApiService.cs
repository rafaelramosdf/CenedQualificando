using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Utils;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.RefitApiServices
{
    public interface IGrupoDePermissaoApiService
    {
        [Post("/grupos-permissoes/filtros")]
        Task<DataTableModel<GrupoDePermissaoDto>> Filtrar([Body] DataTableModel<GrupoDePermissaoDto> dataTableModel);
    }
}
