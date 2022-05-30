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

namespace CenedQualificando.Domain.Handlers.Aluno;

public interface IObterDataTableAlunosQueryHandler : IDataTableQueryHandler<AlunoDto, AlunoFilter> 
{
}

public class ObterDataTableAlunosQueryHandler : IObterDataTableAlunosQueryHandler
{
    private readonly ILogger<ObterDataTableAlunosQueryHandler> Logger;
    private readonly IAlunoQuery Query;
    private readonly IAlunoRepository Repository;
    private readonly IMapper Mapper;

    public ObterDataTableAlunosQueryHandler(
        IAlunoQuery query,
        IAlunoRepository repository,
        IMapper mapper,
        ILogger<ObterDataTableAlunosQueryHandler> logger)
    {
        Logger = logger;
        Query = query;
        Repository = repository;
        Mapper = mapper;
    }

    public DataTableModel<AlunoDto> Execute(AlunoFilter filtro)
    {
        Logger.LogInformation($"Iniciando handler ObterDataTableAlunosQueryHandler");

        var dataTableModel = new DataTableModel<AlunoDto>();

        Expression<Func<Models.Entities.Aluno, bool>> filterExpression = Query.Filtrar(filtro);

        IQueryable<Models.Entities.Aluno> queryList = 
            Repository.List(filterExpression).Include(i => i.Penitenciaria);

        dataTableModel.SortAndPage(queryList, filtro, Query, Mapper);

        return dataTableModel;
    }
}
