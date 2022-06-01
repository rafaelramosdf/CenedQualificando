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

namespace CenedQualificando.Domain.Handlers.CargaHorariaDiaria;

public interface IObterDataTableCargaHorariaDiariaQueryHandler : IDataTableQueryHandler<CargaHorariaDiariaViewModel, CargaHorariaDiariaFilter> 
{
}

public class ObterDataTableCargaHorariaDiariaQueryHandler : IObterDataTableCargaHorariaDiariaQueryHandler
{
    private readonly ILogger<ObterDataTableCargaHorariaDiariaQueryHandler> Logger;
    private readonly ICargaHorariaDiariaQuery Query;
    private readonly ICargaHorariaDiariaRepository Repository;
    private readonly IMapper Mapper;

    public ObterDataTableCargaHorariaDiariaQueryHandler(
        ICargaHorariaDiariaQuery query,
        ICargaHorariaDiariaRepository repository,
        IMapper mapper,
        ILogger<ObterDataTableCargaHorariaDiariaQueryHandler> logger)
    {
        Logger = logger;
        Query = query;
        Repository = repository;
        Mapper = mapper;
    }

    public DataTableModel<CargaHorariaDiariaViewModel> Execute(CargaHorariaDiariaFilter filtro)
    {
        Logger.LogInformation($"Iniciando handler BuscarCargaHorariaDiariaDataTableQueryHandler");

        var dataTableModel = new DataTableModel<CargaHorariaDiariaViewModel>();

        Expression<Func<Models.Entities.CargaHorariaDiaria, bool>> filterExpression = Query.ObterPesquisa(filtro);

        IQueryable<Models.Entities.CargaHorariaDiaria> queryList = 
            Repository.List(filterExpression);

        dataTableModel.SortAndPage(queryList, filtro, Query, Mapper);

        return dataTableModel;
    }
}
