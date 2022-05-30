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

namespace CenedQualificando.Domain.Handlers.UfEntrega;

public interface IObterDataTableUfEntregasQueryHandler : IDataTableQueryHandler<UfEntregaDto, UfEntregaFilter> 
{
}

public class ObterDataTableUfEntregasQueryHandler : IObterDataTableUfEntregasQueryHandler
{
    private readonly ILogger<ObterDataTableUfEntregasQueryHandler> Logger;
    private readonly IUfEntregaQuery Query;
    private readonly IUfEntregaRepository Repository;
    private readonly IMapper Mapper;

    public ObterDataTableUfEntregasQueryHandler(
        IUfEntregaQuery query,
        IUfEntregaRepository repository,
        IMapper mapper,
        ILogger<ObterDataTableUfEntregasQueryHandler> logger)
    {
        Logger = logger;
        Query = query;
        Repository = repository;
        Mapper = mapper;
    }

    public DataTableModel<UfEntregaDto> Execute(UfEntregaFilter filtro)
    {
        Logger.LogInformation($"Iniciando handler ObterDataTableUfEntregasQueryHandler");

        var dataTableModel = new DataTableModel<UfEntregaDto>();

        Expression<Func<Models.Entities.UfEntrega, bool>> filterExpression = Query.Filtrar(filtro);

        IQueryable<Models.Entities.UfEntrega> queryList = 
            Repository.List(filterExpression);

        dataTableModel.SortAndPage(queryList, filtro, Query, Mapper);

        return dataTableModel;
    }
}
