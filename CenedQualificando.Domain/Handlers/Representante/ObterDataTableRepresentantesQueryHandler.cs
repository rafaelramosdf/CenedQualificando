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

namespace CenedQualificando.Domain.Handlers.Representante;

public interface IObterDataTableRepresentantesQueryHandler : IDataTableQueryHandler<RepresentanteDto, RepresentanteFilter> 
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

    public DataTableModel<RepresentanteDto> Execute(RepresentanteFilter filtro)
    {
        Logger.LogInformation($"Iniciando handler ObterDataTableRepresentantesQueryHandler");

        var dataTableModel = new DataTableModel<RepresentanteDto>();

        Expression<Func<Models.Entities.Representante, bool>> filterExpression = Query.Filtrar(filtro);

        IQueryable<Models.Entities.Representante> queryList = 
            Repository.List(filterExpression);

        dataTableModel.SortAndPage(queryList, filtro, Query, Mapper);

        return dataTableModel;
    }
}
