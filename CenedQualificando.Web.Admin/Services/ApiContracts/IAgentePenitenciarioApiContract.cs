﻿using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Web.Admin.Services.ApiContracts.Base;
using CenedQualificando.Domain.Models.Filters;

namespace CenedQualificando.Web.Admin.Services.ApiContracts
{
    public interface IAgentePenitenciarioApiContract 
        : ICrudApiContract<AgentePenitenciario, AgentePenitenciarioFilter, AgentePenitenciarioViewModel>
    {
    }
}
