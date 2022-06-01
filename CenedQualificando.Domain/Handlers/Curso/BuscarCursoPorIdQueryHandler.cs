using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;

namespace CenedQualificando.Domain.Handlers.Curso;

public interface IBuscarCursoPorIdQueryHandler : IByIdQueryHandler<CursoViewModel>
{
}

public class BuscarCursoPorIdQueryHandler : IBuscarCursoPorIdQueryHandler
{
    private readonly ILogger<BuscarCursoPorIdQueryHandler> Logger;
    private readonly ICursoRepository Repository;
    private readonly IMapper Mapper;

    public BuscarCursoPorIdQueryHandler(
        ICursoRepository repository,
        IMapper mapper,
        ILogger<BuscarCursoPorIdQueryHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
    }

    public CursoViewModel Execute(int id)
    {
        Logger.LogInformation($"Iniciando handler BuscarCursoPorIdQueryHandler");
        return Mapper.Map<CursoViewModel>(Repository.Get(id));
    }
}
