using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.Contracts.RefitServices
{
    public interface IRepresentanteRefitService
    {
        [Post("/representantes/filtros")]
        Task<DataTableModel<RepresentanteDto>> Filtrar([Body] DataTableModel<RepresentanteDto> dataTableModel);
    }
}
