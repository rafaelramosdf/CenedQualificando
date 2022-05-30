using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;

namespace CenedQualificando.Domain.Handlers.Matricula;

public interface IBuscarMatriculaPorIdQueryHandler : IByIdQueryHandler<MatriculaDto>
{
}

public class BuscarMatriculaPorIdQueryHandler : IBuscarMatriculaPorIdQueryHandler
{
    private readonly ILogger<BuscarMatriculaPorIdQueryHandler> Logger;
    private readonly IMatriculaRepository Repository;
    private readonly IMapper Mapper;

    public BuscarMatriculaPorIdQueryHandler(
        IMatriculaRepository repository,
        IMapper mapper,
        ILogger<BuscarMatriculaPorIdQueryHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
    }

    public MatriculaDto Execute(int id)
    {
        Logger.LogInformation($"Iniciando handler BuscarMatriculaPorIdQueryHandler");
        return Mapper.Map<MatriculaDto>(Repository.Get(id));
    }
}
