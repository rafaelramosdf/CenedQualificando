using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;

namespace CenedQualificando.Domain.Handlers.UfEntrega;

public interface IBuscarUfEntregaPorIdQueryHandler : IByIdQueryHandler<UfEntregaViewModel>
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

    public UfEntregaViewModel Execute(int id)
    {
        Logger.LogInformation($"Iniciando handler BuscarUfEntregaPorIdQueryHandler");
        return Mapper.Map<UfEntregaViewModel>(Repository.Get(id));
    }
}
