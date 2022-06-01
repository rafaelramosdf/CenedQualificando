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

namespace CenedQualificando.Domain.Handlers.Penitenciaria;

public interface IObterDataTablePenitenciariasQueryHandler : IDataTableQueryHandler<PenitenciariaViewModel, PenitenciariaFilter> 
{
}

public class ObterDataTablePenitenciariasQueryHandler : IObterDataTablePenitenciariasQueryHandler
{
    private readonly ILogger<ObterDataTablePenitenciariasQueryHandler> Logger;
    private readonly IPenitenciariaQuery Query;
    private readonly IPenitenciariaRepository Repository;
    private readonly IMapper Mapper;

    public ObterDataTablePenitenciariasQueryHandler(
        IPenitenciariaQuery query,
        IPenitenciariaRepository repository,
        IMapper mapper,
        ILogger<ObterDataTablePenitenciariasQueryHandler> logger)
    {
        Logger = logger;
        Query = query;
        Repository = repository;
        Mapper = mapper;
    }

    public DataTableModel<PenitenciariaViewModel> Execute(PenitenciariaFilter filtro)
    {
        Logger.LogInformation($"Iniciando handler ObterDataTablePenitenciariasQueryHandler");

        var dataTableModel = new DataTableModel<PenitenciariaViewModel>();

        Expression<Func<Models.Entities.Penitenciaria, bool>> filterExpression = Query.ObterPesquisa(filtro);

        IQueryable<Models.Entities.Penitenciaria> queryList = 
            Repository.List(filterExpression);

        dataTableModel.SortAndPage(queryList, filtro, Query, Mapper);

        return dataTableModel;
    }
}
