using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.Contracts.RefitServices
{
    public interface IUfEntregaRefitService
    {
        [Post("/uf-entregas/filtros")]
        Task<DataTableModel<UfEntregaDto>> Filtrar([Body] DataTableModel<UfEntregaDto> dataTableModel);
    }
}
