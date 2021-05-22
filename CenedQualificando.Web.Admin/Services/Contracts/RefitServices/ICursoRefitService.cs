using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.Contracts.RefitServices
{
    public interface ICursoRefitService
    {
        [Post("/cursos/filtros")]
        Task<DataTableModel<CursoDto>> Filtrar([Body] DataTableModel<CursoDto> dataTableModel);
    }
}
