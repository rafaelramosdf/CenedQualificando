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

namespace CenedQualificando.Domain.Handlers.GrupoDePermissao;

public interface IObterDataTableGrupoDePermissaosQueryHandler : IDataTableQueryHandler<GrupoDePermissaoViewModel, GrupoDePermissaoFilter> 
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

    public DataTableModel<GrupoDePermissaoViewModel> Execute(GrupoDePermissaoFilter filtro)
    {
        Logger.LogInformation($"Iniciando handler ObterDataTableGrupoDePermissaosQueryHandler");

        var dataTableModel = new DataTableModel<GrupoDePermissaoViewModel>();

        IQueryable<Models.Entities.GrupoDePermissao> queryList = Repository
            .List(Query.ObterPesquisa(filtro));

        dataTableModel.SortAndPage(queryList, filtro, Query, Mapper);

        return dataTableModel;
    }
}
