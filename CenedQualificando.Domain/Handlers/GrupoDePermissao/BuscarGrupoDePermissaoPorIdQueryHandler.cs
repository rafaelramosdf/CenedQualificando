using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;

namespace CenedQualificando.Domain.Handlers.GrupoDePermissao;

public interface IBuscarGrupoDePermissaoPorIdQueryHandler : IByIdQueryHandler<GrupoDePermissaoViewModel>
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

    public GrupoDePermissaoViewModel Execute(int id)
    {
        Logger.LogInformation($"Iniciando handler BuscarGrupoDePermissaoPorIdQueryHandler");
        return Mapper.Map<GrupoDePermissaoViewModel>(Repository.Get(id));
    }
}
