using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;

namespace CenedQualificando.Domain.Handlers.AgentePenitenciario;

public interface IBuscarAgentePenitenciarioPorIdQueryHandler : IByIdQueryHandler<AgentePenitenciarioViewModel>
{
}

public class BuscarAgentePenitenciarioPorIdQueryHandler : IBuscarAgentePenitenciarioPorIdQueryHandler
{
    private readonly ILogger<BuscarAgentePenitenciarioPorIdQueryHandler> Logger;
    private readonly IAgentePenitenciarioRepository Repository;
    private readonly IMapper Mapper;

    public BuscarAgentePenitenciarioPorIdQueryHandler(
        IAgentePenitenciarioRepository repository,
        IMapper mapper,
        ILogger<BuscarAgentePenitenciarioPorIdQueryHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
    }

    public AgentePenitenciarioViewModel Execute(int id)
    {
        Logger.LogInformation($"Iniciando handler BuscarAgentePenitenciarioPorIdQueryHandler");
        return Mapper.Map<AgentePenitenciarioViewModel>(Repository.Get(id));
    }
}
