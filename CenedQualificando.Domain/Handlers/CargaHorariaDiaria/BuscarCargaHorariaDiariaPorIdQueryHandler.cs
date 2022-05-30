using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;

namespace CenedQualificando.Domain.Handlers.CargaHorariaDiaria;

public interface IBuscarCargaHorariaDiariaPorIdQueryHandler : IByIdQueryHandler<CargaHorariaDiariaDto>
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

    public CargaHorariaDiariaDto Execute(int id)
    {
        Logger.LogInformation($"Iniciando handler BuscarCargaHorariaDiariaPorIdQueryHandler");
        return Mapper.Map<CargaHorariaDiariaDto>(Repository.Get(id));
    }
}
