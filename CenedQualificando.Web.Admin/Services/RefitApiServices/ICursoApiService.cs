using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Utils;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.RefitApiServices
{
    public interface ICursoApiService
    {
        [Post("/cursos/filtros")]
        Task<DataTableModel<CursoDto>> Filtrar([Body] DataTableModel<CursoDto> dataTableModel);
    }
}
