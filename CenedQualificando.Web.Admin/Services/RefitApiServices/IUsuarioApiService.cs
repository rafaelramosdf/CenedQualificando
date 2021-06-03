using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Utils;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.RefitApiServices
{
    public interface IUsuarioApiService
    {
        [Post("/usuarios/filtros")]
        Task<DataTableModel<UsuarioDto>> Filtrar([Body] DataTableModel<UsuarioDto> dataTableModel);
    }
}
