using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.Contracts.RefitServices
{
    public interface IFiscalSalaRefitService
    {
        [Get("/fiscais-salas")]
        Task<IEnumerable<FiscalSalaDto>> Listar();

        [Post("/fiscais-salas/filtros")]
        Task<DataTableModel<FiscalSalaDto>> Filtrar([Body] DataTableModel<FiscalSalaDto> dataTableModel);
    }
}
