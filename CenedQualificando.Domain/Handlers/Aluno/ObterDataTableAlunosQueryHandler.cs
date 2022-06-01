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

namespace CenedQualificando.Domain.Handlers.Aluno;

public interface IObterDataTableAlunosQueryHandler : IDataTableQueryHandler<AlunoViewModel, AlunoFilter> 
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

    public DataTableModel<AlunoViewModel> Execute(AlunoFilter filtro)
    {
        Logger.LogInformation($"Iniciando handler ObterDataTableAlunosQueryHandler");

        var dataTableModel = new DataTableModel<AlunoViewModel>();

        IQueryable<Models.Entities.Aluno> queryList = Repository
            .List(Query.ObterPesquisa(filtro))
            .Include(i => i.Penitenciaria);

        dataTableModel.SortAndPage(queryList, filtro, Query, Mapper);

        return dataTableModel;
    }
}
