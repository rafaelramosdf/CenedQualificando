using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Queries.Contracts;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Linq.Expressions;
using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Domain.Handlers.Permissao;

public interface IObterDataTablePermissaosQueryHandler : IDataTableQueryHandler<PermissaoViewModel, PermissaoFilter> 
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

    public DataTableModel<PermissaoViewModel> Execute(PermissaoFilter filtro)
    {
        Logger.LogInformation($"Iniciando handler ObterDataTablePermissaosQueryHandler");

        var dataTableModel = new DataTableModel<PermissaoViewModel>();

        IQueryable<Models.Entities.Permissao> queryList = Repository
            .List(Query.ObterPesquisa(filtro))
            .Include(i => i.IdGrupoDePermissaoNavigation);

        dataTableModel.SortAndPage(queryList, filtro, Query, Mapper);

        return dataTableModel;
    }
}
