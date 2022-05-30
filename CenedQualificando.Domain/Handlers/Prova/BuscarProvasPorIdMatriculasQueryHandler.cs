using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Queries.Contracts;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CenedQualificando.Domain.Handlers.Prova;

public interface IBuscarProvasPorIdMatriculasQueryHandler : IEnumerableQueryHandlerAsync<ProvaDto, ProvaFilter>
{
}

public class BuscarProvasPorIdMatriculasQueryHandler : IBuscarProvasPorIdMatriculasQueryHandler
{
    private readonly ILogger<BuscarProvasPorIdMatriculasQueryHandler> Logger;
    private readonly IProvaQuery Query;
    private readonly IProvaRepository Repository;
    private readonly IMapper Mapper;

    public BuscarProvasPorIdMatriculasQueryHandler(
        IProvaQuery query,
        IProvaRepository repository,
        IMapper mapper,
        ILogger<BuscarProvasPorIdMatriculasQueryHandler> logger)
    {
        Logger = logger;
        Query = query;
        Repository = repository;
        Mapper = mapper;
    }

    public async Task<IEnumerable<ProvaDto>> Execute(ProvaFilter filtro)
    {
        Logger.LogInformation($"Iniciando handler BuscarProvasPorIdMatriculasQueryHandler");

        var queryList = await Repository.BuscarProvasPorIdMatriculas(filtro.IdMatriculas);

        var dtoList = Mapper.Map<IEnumerable<Models.Entities.Prova>, IEnumerable<ProvaDto>>(queryList.ToList());

        return dtoList;
    }
}
