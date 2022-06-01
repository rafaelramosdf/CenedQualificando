using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Queries.Contracts;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Linq.Expressions;
using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Domain.Handlers.AgentePenitenciario;

public interface IObterDataTableAgentesPenitenciariosQueryHandler : IDataTableQueryHandler<AgentePenitenciarioViewModel, AgentePenitenciarioFilter> 
{
}

public class ObterDataTableAgentesPenitenciariosQueryHandler : IObterDataTableAgentesPenitenciariosQueryHandler
{
    private readonly ILogger<ObterDataTableAgentesPenitenciariosQueryHandler> Logger;
    private readonly IAgentePenitenciarioQuery Query;
    private readonly IAgentePenitenciarioRepository Repository;
    private readonly IMapper Mapper;

    public ObterDataTableAgentesPenitenciariosQueryHandler(
        IAgentePenitenciarioQuery query,
        IAgentePenitenciarioRepository repository,
        IMapper mapper,
        ILogger<ObterDataTableAgentesPenitenciariosQueryHandler> logger)
    {
        Logger = logger;
        Query = query;
        Repository = repository;
        Mapper = mapper;
    }

    public DataTableModel<AgentePenitenciarioViewModel> Execute(AgentePenitenciarioFilter filtro)
    {
        Logger.LogInformation($"Iniciando handler BuscarAgentePenitenciarioDataTableQueryHandler");

        var dataTableModel = new DataTableModel<AgentePenitenciarioViewModel>();

        IQueryable<Models.Entities.AgentePenitenciario> queryList = Repository
            .List(Query.ObterPesquisa(filtro));

        dataTableModel.SortAndPage(queryList, filtro, Query, Mapper);

        return dataTableModel;
    }
}
