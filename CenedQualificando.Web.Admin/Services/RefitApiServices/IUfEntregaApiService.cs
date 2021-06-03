using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Utils;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.RefitApiServices
{
    public interface IUfEntregaApiService
    {
        [Post("/uf-entregas/filtros")]
        Task<DataTableModel<UfEntregaDto>> Filtrar([Body] DataTableModel<UfEntregaDto> dataTableModel);
    }
}
