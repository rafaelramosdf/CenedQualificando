using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.RefitApiServices
{
    public interface IPenitenciariaApiService
    {
        [Get("/penitenciarias/{id}")]
        Task<PenitenciariaDto> Buscar([AliasAs("id")] int id);

        [Post("/penitenciarias/filtros")]
        Task<DataTableModel<PenitenciariaDto>> Filtrar([Body] DataTableModel<PenitenciariaDto> dataTableModel);
    }
}
