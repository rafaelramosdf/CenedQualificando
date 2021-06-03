using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Utils;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.RefitApiServices
{
    public interface IRepresentanteApiService
    {
        [Post("/representantes/filtros")]
        Task<DataTableModel<RepresentanteDto>> Filtrar([Body] DataTableModel<RepresentanteDto> dataTableModel);
    }
}
