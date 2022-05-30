using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;

namespace CenedQualificando.Domain.Handlers.Usuario;

public interface IBuscarUsuarioPorIdQueryHandler : IByIdQueryHandler<UsuarioDto>
{
}

public class BuscarUsuarioPorIdQueryHandler : IBuscarUsuarioPorIdQueryHandler
{
    private readonly ILogger<BuscarUsuarioPorIdQueryHandler> Logger;
    private readonly IUsuarioRepository Repository;
    private readonly IMapper Mapper;

    public BuscarUsuarioPorIdQueryHandler(
        IUsuarioRepository repository,
        IMapper mapper,
        ILogger<BuscarUsuarioPorIdQueryHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
    }

    public UsuarioDto Execute(int id)
    {
        Logger.LogInformation($"Iniciando handler BuscarUsuarioPorIdQueryHandler");
        return Mapper.Map<UsuarioDto>(Repository.Get(id));
    }
}
