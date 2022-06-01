using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;

namespace CenedQualificando.Domain.Handlers.Permissao;

public interface IBuscarPermissaoPorIdQueryHandler : IByIdQueryHandler<PermissaoViewModel>
{
}

public class BuscarPermissaoPorIdQueryHandler : IBuscarPermissaoPorIdQueryHandler
{
    private readonly ILogger<BuscarPermissaoPorIdQueryHandler> Logger;
    private readonly IPermissaoRepository Repository;
    private readonly IMapper Mapper;

    public BuscarPermissaoPorIdQueryHandler(
        IPermissaoRepository repository,
        IMapper mapper,
        ILogger<BuscarPermissaoPorIdQueryHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
    }

    public PermissaoViewModel Execute(int id)
    {
        Logger.LogInformation($"Iniciando handler BuscarPermissaoPorIdQueryHandler");
        return Mapper.Map<PermissaoViewModel>(Repository.Get(id));
    }
}
