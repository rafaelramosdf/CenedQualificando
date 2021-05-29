using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.RefitApiServices
{
    public interface IAgentePenitenciarioApiService
    {
        [Post("/agentes-penitenciarios/filtros")]
        Task<DataTableModel<AgentePenitenciarioDto>> Filtrar([Body] DataTableModel<AgentePenitenciarioDto> dataTableModel);
    }
}
