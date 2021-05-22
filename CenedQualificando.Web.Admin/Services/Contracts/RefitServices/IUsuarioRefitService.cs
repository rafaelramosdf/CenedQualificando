using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.Contracts.RefitServices
{
    public interface IUsuarioRefitService
    {
        [Post("/usuarios/filtros")]
        Task<DataTableModel<UsuarioDto>> Filtrar([Body] DataTableModel<UsuarioDto> dataTableModel);
    }
}
