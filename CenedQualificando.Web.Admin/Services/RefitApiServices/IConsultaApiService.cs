using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Filters;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.RefitApiServices
{
    public interface IConsultaApiService
    {
        [Post("/matriculas")]
        Task<IEnumerable<MatriculaDto>> Matriculas([Body] MatriculaFilter filtro);
    }
}
