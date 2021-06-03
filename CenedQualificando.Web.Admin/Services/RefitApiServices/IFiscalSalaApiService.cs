using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Utils;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.RefitApiServices
{
    public interface IFiscalSalaApiService
    {
        [Post("/fiscais-salas/filtros")]
        Task<DataTableModel<FiscalSalaDto>> Filtrar([Body] DataTableModel<FiscalSalaDto> dataTableModel);
    }
}
