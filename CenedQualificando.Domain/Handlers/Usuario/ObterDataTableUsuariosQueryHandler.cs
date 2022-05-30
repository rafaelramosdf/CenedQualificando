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

namespace CenedQualificando.Domain.Handlers.Usuario;

public interface IObterDataTableUsuariosQueryHandler : IDataTableQueryHandler<UsuarioDto, UsuarioFilter> 
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

    public DataTableModel<UsuarioDto> Execute(UsuarioFilter filtro)
    {
        Logger.LogInformation($"Iniciando handler ObterDataTableUsuariosQueryHandler");

        var dataTableModel = new DataTableModel<UsuarioDto>();

        Expression<Func<Models.Entities.Usuario, bool>> filterExpression = Query.Filtrar(filtro);

        IQueryable<Models.Entities.Usuario> queryList = 
            Repository.List(filterExpression).Include(i => i.IdGrupoDePermissaoNavigation);

        dataTableModel.SortAndPage(queryList, filtro, Query, Mapper);

        return dataTableModel;
    }
}
