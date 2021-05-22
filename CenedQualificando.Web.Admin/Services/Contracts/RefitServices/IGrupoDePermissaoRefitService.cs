using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.Contracts.RefitServices
{
    public interface IGrupoDePermissaoRefitService
    {
        [Post("/grupos-permissoes/filtros")]
        Task<DataTableModel<GrupoDePermissaoDto>> Filtrar([Body] DataTableModel<GrupoDePermissaoDto> dataTableModel);
    }
}
