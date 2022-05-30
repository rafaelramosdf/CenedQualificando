using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Queries.Contracts;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Handlers.AgentePenitenciario;

public interface IObterDataTableAgentesPenitenciariosQueryHandler : IDataTableQueryHandler<AgentePenitenciarioDto, AgentePenitenciarioFilter> 
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

    public DataTableModel<AgentePenitenciarioDto> Execute(AgentePenitenciarioFilter filtro)
    {
        Logger.LogInformation($"Iniciando handler BuscarAgentePenitenciarioDataTableQueryHandler");

        var dataTableModel = new DataTableModel<AgentePenitenciarioDto>();

        Expression<Func<Models.Entities.AgentePenitenciario, bool>> filterExpression = Query.Filtrar(filtro);

        IQueryable<Models.Entities.AgentePenitenciario> queryList = Repository.List(filterExpression);

        dataTableModel.SortAndPage(queryList, filtro, Query, Mapper);

        return dataTableModel;
    }
}
