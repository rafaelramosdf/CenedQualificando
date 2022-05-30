using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;

namespace CenedQualificando.Domain.Handlers.GrupoDePermissao;

public interface IBuscarGrupoDePermissaoPorIdQueryHandler : IByIdQueryHandler<GrupoDePermissaoDto>
{
}

public class BuscarGrupoDePermissaoPorIdQueryHandler : IBuscarGrupoDePermissaoPorIdQueryHandler
{
    private readonly ILogger<BuscarGrupoDePermissaoPorIdQueryHandler> Logger;
    private readonly IGrupoDePermissaoRepository Repository;
    private readonly IMapper Mapper;

    public BuscarGrupoDePermissaoPorIdQueryHandler(
        IGrupoDePermissaoRepository repository,
        IMapper mapper,
        ILogger<BuscarGrupoDePermissaoPorIdQueryHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
    }

    public GrupoDePermissaoDto Execute(int id)
    {
        Logger.LogInformation($"Iniciando handler BuscarGrupoDePermissaoPorIdQueryHandler");
        return Mapper.Map<GrupoDePermissaoDto>(Repository.Get(id));
    }
}
