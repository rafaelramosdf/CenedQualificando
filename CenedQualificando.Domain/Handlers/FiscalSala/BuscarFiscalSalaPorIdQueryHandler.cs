using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;

namespace CenedQualificando.Domain.Handlers.FiscalSala;

public interface IBuscarFiscalSalaPorIdQueryHandler : IByIdQueryHandler<FiscalSalaViewModel>
{
}

public class BuscarFiscalSalaPorIdQueryHandler : IBuscarFiscalSalaPorIdQueryHandler
{
    private readonly ILogger<BuscarFiscalSalaPorIdQueryHandler> Logger;
    private readonly IFiscalSalaRepository Repository;
    private readonly IMapper Mapper;

    public BuscarFiscalSalaPorIdQueryHandler(
        IFiscalSalaRepository repository,
        IMapper mapper,
        ILogger<BuscarFiscalSalaPorIdQueryHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
    }

    public FiscalSalaViewModel Execute(int id)
    {
        Logger.LogInformation($"Iniciando handler BuscarFiscalSalaPorIdQueryHandler");
        return Mapper.Map<FiscalSalaViewModel>(Repository.Get(id));
    }
}
