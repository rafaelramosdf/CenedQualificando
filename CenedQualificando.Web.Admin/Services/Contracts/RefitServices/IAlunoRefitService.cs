using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.Contracts.RefitServices
{
    public interface IAlunoRefitService
    {
        [Post("/alunos/filtros")]
        Task<DataTableModel<AlunoDto>> Filtrar([Body] DataTableModel<AlunoDto> dataTableModel);
    }
}
