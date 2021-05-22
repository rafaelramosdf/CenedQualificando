using System.Threading.Tasks;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;

namespace CenedQualificando.Web.Admin.Services.Contracts
{
    public interface IPenitenciariaService
    {
        public Task<DataTableModel<PenitenciariaDto>> Filtrar(DataTableModel<PenitenciariaDto> dataTableModel);
    }
}
