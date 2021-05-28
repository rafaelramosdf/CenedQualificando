using System.Collections.Generic;
using System.Threading.Tasks;
using CenedQualificando.Domain.Models.Objects;

namespace CenedQualificando.Web.Admin.Services.Contracts
{
    public interface IComboEntidadeService
    {
        public Task<IEnumerable<SelectResult>> Penitenciarias(SelectSearchParam param);
    }
}
