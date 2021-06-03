using CenedQualificando.Domain.Models.Utils;
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
    }
}
