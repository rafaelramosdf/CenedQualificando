using CenedQualificando.Domain.Models.Base;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.RefitApiServices
{
    public interface IComboEntidadeApiService
    {
        [Get("/penitenciarias")]
        Task<IEnumerable<SelectResult>> Penitenciarias([Query] SelectSearchParam param);

        [Get("/alunos")]
        Task<IEnumerable<SelectResult>> Alunos([Query] SelectSearchParam param);

        [Get("/cursos")]
        Task<IEnumerable<SelectResult>> Cursos([Query] SelectSearchParam param);

        [Get("/usuarios")]
        Task<IEnumerable<SelectResult>> Usuarios([Query] SelectSearchParam param);
    }
}
