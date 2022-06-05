using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Models.ViewModels;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Fiscalizacao.Services.ApiContracts
{
    public interface IMatriculaApiContract
    {
        [Get("")]
        Task<DataTableModel<MatriculaViewModel>> Buscar([Query] MatriculaFilter filtro);
    }
}
