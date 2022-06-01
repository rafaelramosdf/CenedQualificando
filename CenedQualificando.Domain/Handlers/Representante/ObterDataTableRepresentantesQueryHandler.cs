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

namespace CenedQualificando.Domain.Handlers.Representante;

public interface IObterDataTableRepresentantesQueryHandler : IDataTableQueryHandler<RepresentanteViewModel, RepresentanteFilter> 
{
}

public class ObterDataTableRepresentantesQueryHandler : IObterDataTableRepresentantesQueryHandler
{
    private readonly ILogger<ObterDataTableRepresentantesQueryHandler> Logger;
    private readonly IRepresentanteQuery Query;
    private readonly IRepresentanteRepository Repository;
    private readonly IMapper Mapper;

    public ObterDataTableRepresentantesQueryHandler(
        IRepresentanteQuery query,
        IRepresentanteRepository repository,
        IMapper mapper,
        ILogger<ObterDataTableRepresentantesQueryHandler> logger)
    {
        Logger = logger;
        Query = query;
        Repository = repository;
        Mapper = mapper;
    }

    public DataTableModel<RepresentanteViewModel> Execute(RepresentanteFilter filtro)
    {
        Logger.LogInformation($"Iniciando handler ObterDataTableRepresentantesQueryHandler");

        var dataTableModel = new DataTableModel<RepresentanteViewModel>();

        Expression<Func<Models.Entities.Representante, bool>> filterExpression = Query.ObterPesquisa(filtro);

        IQueryable<Models.Entities.Representante> queryList = 
            Repository.List(filterExpression);

        dataTableModel.SortAndPage(queryList, filtro, Query, Mapper);

        return dataTableModel;
    }
}
