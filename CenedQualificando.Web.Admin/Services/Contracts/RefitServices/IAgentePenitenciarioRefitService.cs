using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.Contracts.RefitServices
{
    public interface IAgentePenitenciarioRefitService
    {
        [Post("/agentes-penitenciarios/filtros")]
        Task<DataTableModel<AgentePenitenciarioDto>> Filtrar([Body] DataTableModel<AgentePenitenciarioDto> dataTableModel);
    }
}
