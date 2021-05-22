using System.Threading.Tasks;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;

namespace CenedQualificando.Web.Admin.Services.Contracts
{
    public interface IProvaService
    {
        public Task<DataTableModel<ProvaDto>> Filtrar(DataTableModel<ProvaDto> dataTableModel);
    }
}
