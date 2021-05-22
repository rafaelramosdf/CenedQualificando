using System.Threading.Tasks;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;

namespace CenedQualificando.Web.Admin.Services.Contracts
{
    public interface IGrupoDePermissaoService
    {
        public Task<DataTableModel<GrupoDePermissaoDto>> Filtrar(DataTableModel<GrupoDePermissaoDto> dataTableModel);
    }
}
