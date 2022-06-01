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

namespace CenedQualificando.Domain.Handlers.UfEntrega;

public interface IObterDataTableUfEntregasQueryHandler : IDataTableQueryHandler<UfEntregaViewModel, UfEntregaFilter> 
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

    public DataTableModel<UfEntregaViewModel> Execute(UfEntregaFilter filtro)
    {
        Logger.LogInformation($"Iniciando handler ObterDataTableUfEntregasQueryHandler");

        var dataTableModel = new DataTableModel<UfEntregaViewModel>();

        IQueryable<Models.Entities.UfEntrega> queryList = 
            Repository.List(Query.ObterPesquisa(filtro));

        dataTableModel.SortAndPage(queryList, filtro, Query, Mapper);

        return dataTableModel;
    }
}
