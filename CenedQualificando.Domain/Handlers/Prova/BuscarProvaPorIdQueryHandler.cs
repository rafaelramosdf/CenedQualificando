using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;

namespace CenedQualificando.Domain.Handlers.Prova;

public interface IBuscarProvaPorIdQueryHandler : IByIdQueryHandler<ProvaViewModel>
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

    public ProvaViewModel Execute(int id)
    {
        Logger.LogInformation($"Iniciando handler BuscarProvaPorIdQueryHandler");
        return Mapper.Map<ProvaViewModel>(Repository.Get(id));
    }
}
