using System.Threading.Tasks;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;

namespace CenedQualificando.Web.Admin.Services.Contracts
{
    public interface IPermissaoService
    {
        public Task<DataTableModel<PermissaoDto>> Filtrar(DataTableModel<PermissaoDto> dataTableModel);
    }
}
