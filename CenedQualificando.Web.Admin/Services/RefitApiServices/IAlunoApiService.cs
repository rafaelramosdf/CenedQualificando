using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Utils;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.RefitApiServices
{
    public interface IAlunoApiService
    {
        [Get("/alunos/{id}")]
        Task<AlunoDto> Buscar([AliasAs("id")] int id);

        [Post("/alunos/filtros")]
        Task<DataTableModel<AlunoDto>> Filtrar([Body] DataTableModel<AlunoDto> dataTableModel);
    }
}
