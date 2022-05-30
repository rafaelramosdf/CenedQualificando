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

namespace CenedQualificando.Domain.Handlers.Curso;

public interface IObterDataTableCursosQueryHandler : IDataTableQueryHandler<CursoDto, CursoFilter> 
{
}

public class ObterDataTableCursosQueryHandler : IObterDataTableCursosQueryHandler
{
    private readonly ILogger<ObterDataTableCursosQueryHandler> Logger;
    private readonly ICursoQuery Query;
    private readonly ICursoRepository Repository;
    private readonly IMapper Mapper;

    public ObterDataTableCursosQueryHandler(
        ICursoQuery query,
        ICursoRepository repository,
        IMapper mapper,
        ILogger<ObterDataTableCursosQueryHandler> logger)
    {
        Logger = logger;
        Query = query;
        Repository = repository;
        Mapper = mapper;
    }

    public DataTableModel<CursoDto> Execute(CursoFilter filtro)
    {
        Logger.LogInformation($"Iniciando handler BuscarCursoDataTableQueryHandler");

        var dataTableModel = new DataTableModel<CursoDto>();

        Expression<Func<Models.Entities.Curso, bool>> filterExpression = Query.Filtrar(filtro);

        IQueryable<Models.Entities.Curso> queryList = 
            Repository.List(filterExpression).Include(i => i.Conteudo);

        dataTableModel.SortAndPage(queryList, filtro, Query, Mapper);

        return dataTableModel;
    }
}
