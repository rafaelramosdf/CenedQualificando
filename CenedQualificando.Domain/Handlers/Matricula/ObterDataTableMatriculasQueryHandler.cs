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

namespace CenedQualificando.Domain.Handlers.Matricula;

public interface IObterDataTableMatriculasQueryHandler : IDataTableQueryHandler<MatriculaDto, MatriculaFilter> 
{
}

public class ObterDataTableMatriculasQueryHandler : IObterDataTableMatriculasQueryHandler
{
    private readonly ILogger<ObterDataTableMatriculasQueryHandler> Logger;
    private readonly IMatriculaQuery Query;
    private readonly IMatriculaRepository Repository;
    private readonly IMapper Mapper;

    public ObterDataTableMatriculasQueryHandler(
        IMatriculaQuery query,
        IMatriculaRepository repository,
        IMapper mapper,
        ILogger<ObterDataTableMatriculasQueryHandler> logger)
    {
        Logger = logger;
        Query = query;
        Repository = repository;
        Mapper = mapper;
    }

    public DataTableModel<MatriculaDto> Execute(MatriculaFilter filtro)
    {
        Logger.LogInformation($"Iniciando handler ObterDataTableMatriculasQueryHandler");

        var dataTableModel = new DataTableModel<MatriculaDto>();

        Expression<Func<Models.Entities.Matricula, bool>> filterExpression = Query.Filtrar(filtro);

        IQueryable<Models.Entities.Matricula> queryList = 
            Repository.List(filterExpression)
            .Include(i => i.Aluno)
            .Include(i => i.Curso);

        dataTableModel.SortAndPage(queryList, filtro, Query, Mapper);

        return dataTableModel;
    }
}
