using System.Threading.Tasks;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;

namespace CenedQualificando.Web.Admin.Services.Contracts
{
    public interface IUsuarioService
    {
        public Task<DataTableModel<UsuarioDto>> Filtrar(DataTableModel<UsuarioDto> dataTableModel);
    }
}
