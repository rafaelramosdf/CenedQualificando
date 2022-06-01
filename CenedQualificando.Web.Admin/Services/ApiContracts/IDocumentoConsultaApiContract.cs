using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Filters;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.ApiContracts
{
    public interface IDocumentoConsultaApiContract
    {
        [Get("/matriculas")]
        Task<IEnumerable<MatriculaViewModel>> Matriculas([Query] MatriculaFilter filtro);
    }
}
