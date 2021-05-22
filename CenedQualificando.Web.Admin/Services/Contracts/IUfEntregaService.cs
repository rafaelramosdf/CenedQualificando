using System.Threading.Tasks;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;

namespace CenedQualificando.Web.Admin.Services.Contracts
{
    public interface IUfEntregaService
    {
        public Task<DataTableModel<UfEntregaDto>> Filtrar(DataTableModel<UfEntregaDto> dataTableModel);
    }
}
