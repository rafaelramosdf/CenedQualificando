using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;

namespace CenedQualificando.Domain.Handlers.Aluno;

public interface IBuscarAlunoPorIdQueryHandler : IByIdQueryHandler<AlunoViewModel>
{
}

public class BuscarAlunoPorIdQueryHandler : IBuscarAlunoPorIdQueryHandler
{
    private readonly ILogger<BuscarAlunoPorIdQueryHandler> Logger;
    private readonly IAlunoRepository Repository;
    private readonly IMapper Mapper;

    public BuscarAlunoPorIdQueryHandler(
        IAlunoRepository repository,
        IMapper mapper,
        ILogger<BuscarAlunoPorIdQueryHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
    }

    public AlunoViewModel Execute(int id)
    {
        Logger.LogInformation($"Iniciando handler BuscarAlunoPorIdQueryHandler");
        return Mapper.Map<AlunoViewModel>(Repository.Get(id));
    }
}
