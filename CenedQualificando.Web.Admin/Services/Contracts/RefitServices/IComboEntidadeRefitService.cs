using CenedQualificando.Domain.Models.Objects;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.Contracts.RefitServices
{
    public interface IComboEntidadeRefitService
    {
        [Get("/penitenciarias")]
        Task<IEnumerable<SelectResult>> Penitenciarias([Query] SelectSearchParam param);
    }
}
