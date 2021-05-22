using System.Threading.Tasks;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;

namespace CenedQualificando.Web.Admin.Services.Contracts
{
    public interface IFiscalSalaService
    {
        public Task<DataTableModel<FiscalSalaDto>> Filtrar(DataTableModel<FiscalSalaDto> dataTableModel);
    }
}
