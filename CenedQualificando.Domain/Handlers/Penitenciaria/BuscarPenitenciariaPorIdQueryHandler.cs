using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;

namespace CenedQualificando.Domain.Handlers.Penitenciaria;

public interface IBuscarPenitenciariaPorIdQueryHandler : IByIdQueryHandler<PenitenciariaDto>
{
}

public class BuscarPenitenciariaPorIdQueryHandler : IBuscarPenitenciariaPorIdQueryHandler
{
    private readonly ILogger<BuscarPenitenciariaPorIdQueryHandler> Logger;
    private readonly IPenitenciariaRepository Repository;
    private readonly IMapper Mapper;

    public BuscarPenitenciariaPorIdQueryHandler(
        IPenitenciariaRepository repository,
        IMapper mapper,
        ILogger<BuscarPenitenciariaPorIdQueryHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
    }

    public PenitenciariaDto Execute(int id)
    {
        Logger.LogInformation($"Iniciando handler BuscarPenitenciariaPorIdQueryHandler");
        return Mapper.Map<PenitenciariaDto>(Repository.Get(id));
    }
}
