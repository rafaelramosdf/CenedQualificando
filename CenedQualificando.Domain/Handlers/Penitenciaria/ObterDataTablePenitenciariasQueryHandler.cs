using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Queries.Contracts;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Handlers.Penitenciaria;

public interface IObterDataTablePenitenciariasQueryHandler : IDataTableQueryHandler<PenitenciariaDto, PenitenciariaFilter> 
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

    public DataTableModel<PenitenciariaDto> Execute(PenitenciariaFilter filtro)
    {
        Logger.LogInformation($"Iniciando handler ObterDataTablePenitenciariasQueryHandler");

        var dataTableModel = new DataTableModel<PenitenciariaDto>();

        Expression<Func<Models.Entities.Penitenciaria, bool>> filterExpression = Query.Filtrar(filtro);

        IQueryable<Models.Entities.Penitenciaria> queryList = 
            Repository.List(filterExpression);

        dataTableModel.SortAndPage(queryList, filtro, Query, Mapper);

        return dataTableModel;
    }
}
