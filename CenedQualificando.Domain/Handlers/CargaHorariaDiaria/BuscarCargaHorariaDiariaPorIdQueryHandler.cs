using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;

namespace CenedQualificando.Domain.Handlers.CargaHorariaDiaria;

public interface IBuscarCargaHorariaDiariaPorIdQueryHandler : IByIdQueryHandler<CargaHorariaDiariaViewModel>
{
}

public class BuscarCargaHorariaDiariaPorIdQueryHandler : IBuscarCargaHorariaDiariaPorIdQueryHandler
{
    private readonly ILogger<BuscarCargaHorariaDiariaPorIdQueryHandler> Logger;
    private readonly ICargaHorariaDiariaRepository Repository;
    private readonly IMapper Mapper;

    public BuscarCargaHorariaDiariaPorIdQueryHandler(
        ICargaHorariaDiariaRepository repository,
        IMapper mapper,
        ILogger<BuscarCargaHorariaDiariaPorIdQueryHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
    }

    public CargaHorariaDiariaViewModel Execute(int id)
    {
        Logger.LogInformation($"Iniciando handler BuscarCargaHorariaDiariaPorIdQueryHandler");
        return Mapper.Map<CargaHorariaDiariaViewModel>(Repository.Get(id));
    }
}
