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

namespace CenedQualificando.Domain.Handlers.GrupoDePermissao;

public interface IObterDataTableGrupoDePermissaosQueryHandler : IDataTableQueryHandler<GrupoDePermissaoDto, GrupoDePermissaoFilter> 
{
}

public class ObterDataTableGrupoDePermissaosQueryHandler : IObterDataTableGrupoDePermissaosQueryHandler
{
    private readonly ILogger<ObterDataTableGrupoDePermissaosQueryHandler> Logger;
    private readonly IGrupoDePermissaoQuery Query;
    private readonly IGrupoDePermissaoRepository Repository;
    private readonly IMapper Mapper;

    public ObterDataTableGrupoDePermissaosQueryHandler(
        IGrupoDePermissaoQuery query,
        IGrupoDePermissaoRepository repository,
        IMapper mapper,
        ILogger<ObterDataTableGrupoDePermissaosQueryHandler> logger)
    {
        Logger = logger;
        Query = query;
        Repository = repository;
        Mapper = mapper;
    }

    public DataTableModel<GrupoDePermissaoDto> Execute(GrupoDePermissaoFilter filtro)
    {
        Logger.LogInformation($"Iniciando handler ObterDataTableGrupoDePermissaosQueryHandler");

        var dataTableModel = new DataTableModel<GrupoDePermissaoDto>();

        Expression<Func<Models.Entities.GrupoDePermissao, bool>> filterExpression = Query.Filtrar(filtro);

        IQueryable<Models.Entities.GrupoDePermissao> queryList = 
            Repository.List(filterExpression);

        dataTableModel.SortAndPage(queryList, filtro, Query, Mapper);

        return dataTableModel;
    }
}
