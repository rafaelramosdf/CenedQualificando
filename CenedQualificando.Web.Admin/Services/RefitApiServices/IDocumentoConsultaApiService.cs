using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Filters;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.RefitApiServices
{
    public interface IDocumentoConsultaApiService
    {
        [Post("/matriculas")]
        Task<IEnumerable<MatriculaViewModel>> Matriculas([Body] MatriculaFilter filtro);
    }
}
