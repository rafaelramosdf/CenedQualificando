using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.Contracts.RefitServices
{
    public interface IPenitenciariaRefitService
    {
        [Post("/penitenciarias/filtros")]
        Task<DataTableModel<PenitenciariaDto>> Filtrar([Body] DataTableModel<PenitenciariaDto> dataTableModel);
    }
}
