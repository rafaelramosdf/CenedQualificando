using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.Contracts.RefitServices
{
    public interface IFiscalSalaRefitService
    {
        [Post("/fiscais-salas/filtros")]
        Task<DataTableModel<FiscalSalaDto>> Filtrar([Body] DataTableModel<FiscalSalaDto> dataTableModel);
    }
}
