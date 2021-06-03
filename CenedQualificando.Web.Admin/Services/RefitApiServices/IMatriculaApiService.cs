using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Utils;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.RefitApiServices
{
    public interface IMatriculaApiService
    {
        [Post("/matriculas/filtros")]
        Task<DataTableModel<MatriculaDto>> Filtrar([Body] DataTableModel<MatriculaDto> dataTableModel);
    }
}
