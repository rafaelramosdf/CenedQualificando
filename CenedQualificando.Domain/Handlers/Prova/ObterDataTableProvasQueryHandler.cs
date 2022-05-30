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

namespace CenedQualificando.Domain.Handlers.Prova;

public interface IObterDataTableProvasQueryHandler : IDataTableQueryHandler<ProvaDto, ProvaFilter> 
{
}

public class ObterDataTableProvasQueryHandler : IObterDataTableProvasQueryHandler
{
    private readonly ILogger<ObterDataTableProvasQueryHandler> Logger;
    private readonly IProvaQuery Query;
    private readonly IProvaRepository Repository;
    private readonly IMapper Mapper;

    public ObterDataTableProvasQueryHandler(
        IProvaQuery query,
        IProvaRepository repository,
        IMapper mapper,
        ILogger<ObterDataTableProvasQueryHandler> logger)
    {
        Logger = logger;
        Query = query;
        Repository = repository;
        Mapper = mapper;
    }

    public DataTableModel<ProvaDto> Execute(ProvaFilter filtro)
    {
        Logger.LogInformation($"Iniciando handler ObterDataTableProvasQueryHandler");

        var dataTableModel = new DataTableModel<ProvaDto>();

        Expression<Func<Models.Entities.Prova, bool>> filterExpression = Query.Filtrar(filtro);

        IQueryable<Models.Entities.Prova> queryList = 
            Repository.List(filterExpression);

        dataTableModel.SortAndPage(queryList, filtro, Query, Mapper);

        return dataTableModel;
    }
}
