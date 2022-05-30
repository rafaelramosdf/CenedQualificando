using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Queries.Contracts;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Handlers.Permissao;

public interface IObterDataTablePermissaosQueryHandler : IDataTableQueryHandler<PermissaoDto, PermissaoFilter> 
{
}

public class ObterDataTablePermissaosQueryHandler : IObterDataTablePermissaosQueryHandler
{
    private readonly ILogger<ObterDataTablePermissaosQueryHandler> Logger;
    private readonly IPermissaoQuery Query;
    private readonly IPermissaoRepository Repository;
    private readonly IMapper Mapper;

    public ObterDataTablePermissaosQueryHandler(
        IPermissaoQuery query,
        IPermissaoRepository repository,
        IMapper mapper,
        ILogger<ObterDataTablePermissaosQueryHandler> logger)
    {
        Logger = logger;
        Query = query;
        Repository = repository;
        Mapper = mapper;
    }

    public DataTableModel<PermissaoDto> Execute(PermissaoFilter filtro)
    {
        Logger.LogInformation($"Iniciando handler ObterDataTablePermissaosQueryHandler");

        var dataTableModel = new DataTableModel<PermissaoDto>();

        Expression<Func<Models.Entities.Permissao, bool>> filterExpression = Query.Filtrar(filtro);

        IQueryable<Models.Entities.Permissao> queryList = 
            Repository.List(filterExpression).Include(i => i.IdGrupoDePermissaoNavigation);

        dataTableModel.SortAndPage(queryList, filtro, Query, Mapper);

        return dataTableModel;
    }
}
