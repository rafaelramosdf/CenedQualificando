using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;

namespace CenedQualificando.Domain.Handlers.UfEntrega;

public interface IBuscarUfEntregaPorIdQueryHandler : IByIdQueryHandler<UfEntregaDto>
{
}

public class BuscarUfEntregaPorIdQueryHandler : IBuscarUfEntregaPorIdQueryHandler
{
    private readonly ILogger<BuscarUfEntregaPorIdQueryHandler> Logger;
    private readonly IUfEntregaRepository Repository;
    private readonly IMapper Mapper;

    public BuscarUfEntregaPorIdQueryHandler(
        IUfEntregaRepository repository,
        IMapper mapper,
        ILogger<BuscarUfEntregaPorIdQueryHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
    }

    public UfEntregaDto Execute(int id)
    {
        Logger.LogInformation($"Iniciando handler BuscarUfEntregaPorIdQueryHandler");
        return Mapper.Map<UfEntregaDto>(Repository.Get(id));
    }
}
