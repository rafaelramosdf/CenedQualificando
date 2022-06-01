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

namespace CenedQualificando.Domain.Handlers.Usuario;

public interface IObterDataTableUsuariosQueryHandler : IDataTableQueryHandler<UsuarioViewModel, UsuarioFilter> 
{
}

public class ObterDataTableUsuariosQueryHandler : IObterDataTableUsuariosQueryHandler
{
    private readonly ILogger<ObterDataTableUsuariosQueryHandler> Logger;
    private readonly IUsuarioQuery Query;
    private readonly IUsuarioRepository Repository;
    private readonly IMapper Mapper;

    public ObterDataTableUsuariosQueryHandler(
        IUsuarioQuery query,
        IUsuarioRepository repository,
        IMapper mapper,
        ILogger<ObterDataTableUsuariosQueryHandler> logger)
    {
        Logger = logger;
        Query = query;
        Repository = repository;
        Mapper = mapper;
    }

    public DataTableModel<UsuarioViewModel> Execute(UsuarioFilter filtro)
    {
        Logger.LogInformation($"Iniciando handler ObterDataTableUsuariosQueryHandler");

        var dataTableModel = new DataTableModel<UsuarioViewModel>();

        IQueryable<Models.Entities.Usuario> queryList = Repository
            .List(Query.ObterPesquisa(filtro))
            .Include(i => i.IdGrupoDePermissaoNavigation);

        dataTableModel.SortAndPage(queryList, filtro, Query, Mapper);

        return dataTableModel;
    }
}
