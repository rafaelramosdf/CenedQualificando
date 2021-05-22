﻿using System.Threading.Tasks;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;

namespace CenedQualificando.Web.Admin.Services.Contracts
{
    public interface IAgentePenitenciarioService
    {
        public Task<DataTableModel<AgentePenitenciarioDto>> Filtrar(DataTableModel<AgentePenitenciarioDto> dataTableModel);
    }
}
