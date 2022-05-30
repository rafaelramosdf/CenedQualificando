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

namespace CenedQualificando.Domain.Handlers.FiscalSala;

public interface IObterDataTableFiscalSalaQueryHandler : IDataTableQueryHandler<FiscalSalaDto, FiscalSalaFilter> 
{
}

public class ObterDataTableFiscalSalaQueryHandler : IObterDataTableFiscalSalaQueryHandler
{
    private readonly ILogger<ObterDataTableFiscalSalaQueryHandler> Logger;
    private readonly IFiscalSalaQuery Query;
    private readonly IFiscalSalaRepository Repository;
    private readonly IMapper Mapper;

    public ObterDataTableFiscalSalaQueryHandler(
        IFiscalSalaQuery query,
        IFiscalSalaRepository repository,
        IMapper mapper,
        ILogger<ObterDataTableFiscalSalaQueryHandler> logger)
    {
        Logger = logger;
        Query = query;
        Repository = repository;
        Mapper = mapper;
    }

    public DataTableModel<FiscalSalaDto> Execute(FiscalSalaFilter filtro)
    {
        Logger.LogInformation($"Iniciando handler BuscarFiscalSalaDataTableQueryHandler");

        var dataTableModel = new DataTableModel<FiscalSalaDto>();

        Expression<Func<Models.Entities.FiscalSala, bool>> filterExpression = Query.Filtrar(filtro);

        IQueryable<Models.Entities.FiscalSala> queryList = 
            Repository.List(filterExpression);

        dataTableModel.SortAndPage(queryList, filtro, Query, Mapper);

        return dataTableModel;
    }
}
