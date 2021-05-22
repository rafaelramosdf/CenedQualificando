using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.Contracts.RefitServices
{
    public interface IMatriculaRefitService
    {
        [Post("/matriculas/filtros")]
        Task<DataTableModel<MatriculaDto>> Filtrar([Body] DataTableModel<MatriculaDto> dataTableModel);
    }
}
