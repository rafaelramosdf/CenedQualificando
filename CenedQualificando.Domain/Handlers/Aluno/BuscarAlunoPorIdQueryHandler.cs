using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;

namespace CenedQualificando.Domain.Handlers.Aluno;

public interface IBuscarAlunoPorIdQueryHandler : IByIdQueryHandler<AlunoDto>
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

    public AlunoDto Execute(int id)
    {
        Logger.LogInformation($"Iniciando handler BuscarAlunoPorIdQueryHandler");
        return Mapper.Map<AlunoDto>(Repository.Get(id));
    }
}
