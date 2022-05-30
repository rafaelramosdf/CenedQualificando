using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;

namespace CenedQualificando.Domain.Handlers.Prova;

public interface IBuscarProvaPorIdQueryHandler : IByIdQueryHandler<ProvaDto>
{
}

public class BuscarProvaPorIdQueryHandler : IBuscarProvaPorIdQueryHandler
{
    private readonly ILogger<BuscarProvaPorIdQueryHandler> Logger;
    private readonly IProvaRepository Repository;
    private readonly IMapper Mapper;

    public BuscarProvaPorIdQueryHandler(
        IProvaRepository repository,
        IMapper mapper,
        ILogger<BuscarProvaPorIdQueryHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
    }

    public ProvaDto Execute(int id)
    {
        Logger.LogInformation($"Iniciando handler BuscarProvaPorIdQueryHandler");
        return Mapper.Map<ProvaDto>(Repository.Get(id));
    }
}
