using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Domain.Models.Utils;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.RefitApiServices
{
    public interface IProvaApiService
    {
        [Post("/provas/filtros")]
        Task<DataTableModel<ProvaDto>> Filtrar([Body] DataTableModel<ProvaDto> dataTableModel);
    }
}
