using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using CenedQualificando.Web.Admin.Services.Contracts;
using CenedQualificando.Web.Admin.Services.Contracts.RefitServices;
using Refit;
using System;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services
{
    public class AgentePenitenciarioService : IAgentePenitenciarioService
    {
        private IAgentePenitenciarioRefitService _refitService;

        public AgentePenitenciarioService()
        {
            _refitService = RestService.For<IAgentePenitenciarioRefitService>("https://localhost:6001/api");
        }

        public async Task<DataTableModel<AgentePenitenciarioDto>> Filtrar(DataTableModel<AgentePenitenciarioDto> dataTableModel)
        {
            try
            {
                return await _refitService.Filtrar(dataTableModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
