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

namespace CenedQualificando.Domain.Handlers.Prova;

public interface IObterDataTableProvasQueryHandler : IDataTableQueryHandler<ProvaViewModel, ProvaFilter> 
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

    public DataTableModel<ProvaViewModel> Execute(ProvaFilter filtro)
    {
        Logger.LogInformation($"Iniciando handler ObterDataTableProvasQueryHandler");

        var dataTableModel = new DataTableModel<ProvaViewModel>();

        Expression<Func<Models.Entities.Prova, bool>> filterExpression = Query.ObterPesquisa(filtro);

        IQueryable<Models.Entities.Prova> queryList = 
            Repository.List(filterExpression);

        dataTableModel.SortAndPage(queryList, filtro, Query, Mapper);

        return dataTableModel;
    }
}
