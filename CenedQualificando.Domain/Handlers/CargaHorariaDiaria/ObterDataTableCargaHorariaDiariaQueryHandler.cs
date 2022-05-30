﻿using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Queries.Contracts;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Handlers.CargaHorariaDiaria;

public interface IObterDataTableCargaHorariaDiariaQueryHandler : IDataTableQueryHandler<CargaHorariaDiariaDto, CargaHorariaDiariaFilter> 
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

    public DataTableModel<CargaHorariaDiariaDto> Execute(CargaHorariaDiariaFilter filtro)
    {
        Logger.LogInformation($"Iniciando handler BuscarCargaHorariaDiariaDataTableQueryHandler");

        var dataTableModel = new DataTableModel<CargaHorariaDiariaDto>();

        Expression<Func<Models.Entities.CargaHorariaDiaria, bool>> filterExpression = Query.Filtrar(filtro);

        IQueryable<Models.Entities.CargaHorariaDiaria> queryList = 
            Repository.List(filterExpression);

        dataTableModel.SortAndPage(queryList, filtro, Query, Mapper);

        return dataTableModel;
    }
}
