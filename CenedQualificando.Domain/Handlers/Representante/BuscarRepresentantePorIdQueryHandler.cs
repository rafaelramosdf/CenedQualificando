using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;

namespace CenedQualificando.Domain.Handlers.Representante;

public interface IBuscarRepresentantePorIdQueryHandler : IByIdQueryHandler<RepresentanteDto>
{
}

public class BuscarRepresentantePorIdQueryHandler : IBuscarRepresentantePorIdQueryHandler
{
    private readonly ILogger<BuscarRepresentantePorIdQueryHandler> Logger;
    private readonly IRepresentanteRepository Repository;
    private readonly IMapper Mapper;

    public BuscarRepresentantePorIdQueryHandler(
        IRepresentanteRepository repository,
        IMapper mapper,
        ILogger<BuscarRepresentantePorIdQueryHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
    }

    public RepresentanteDto Execute(int id)
    {
        Logger.LogInformation($"Iniciando handler BuscarRepresentantePorIdQueryHandler");
        return Mapper.Map<RepresentanteDto>(Repository.Get(id));
    }
}
