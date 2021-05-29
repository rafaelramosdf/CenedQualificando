using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.RefitApiServices
{
    public interface IAlunoApiService
    {
        [Post("/alunos/filtros")]
        Task<DataTableModel<AlunoDto>> Filtrar([Body] DataTableModel<AlunoDto> dataTableModel);
    }
}
