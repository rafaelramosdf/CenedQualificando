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

namespace CenedQualificando.Domain.Handlers.FiscalSala;

public interface IObterDataTableFiscalSalaQueryHandler : IDataTableQueryHandler<FiscalSalaViewModel, FiscalSalaFilter> 
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

    public DataTableModel<FiscalSalaViewModel> Execute(FiscalSalaFilter filtro)
    {
        Logger.LogInformation($"Iniciando handler BuscarFiscalSalaDataTableQueryHandler");

        var dataTableModel = new DataTableModel<FiscalSalaViewModel>();

        IQueryable<Models.Entities.FiscalSala> queryList = Repository
            .List(Query.ObterPesquisa(filtro));

        dataTableModel.SortAndPage(queryList, filtro, Query, Mapper);

        return dataTableModel;
    }
}
