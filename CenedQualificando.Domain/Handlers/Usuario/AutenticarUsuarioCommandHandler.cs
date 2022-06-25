using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Repositories.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using CenedQualificando.Domain.Models.Dtos;
using System.Linq;

namespace CenedQualificando.Domain.Handlers.Usuario;

public interface IAutenticarUsuarioCommandHandler : IDtoCommandHandler<AutenticacaoUsuarioDto, UsuarioViewModel>
{
}

public class AutenticarUsuarioCommandHandler : IAutenticarUsuarioCommandHandler
{
    private readonly ILogger<AutenticarUsuarioCommandHandler> Logger;
    private readonly IUsuarioRepository Repository;
    private readonly IPermissaoRepository PermissaoRepository;
    protected readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public AutenticarUsuarioCommandHandler(
        IUsuarioRepository repository,
        IPermissaoRepository permissaoRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<AutenticarUsuarioCommandHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        PermissaoRepository = permissaoRepository;
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public UsuarioViewModel Execute(AutenticacaoUsuarioDto dto)
    {
        Logger.LogInformation($"Iniciando handler AutenticarUsuarioCommandHandler");

        try
        {
            var usuarioAutenticado = Repository
                .List(u => u.Login == dto.Usuario && u.Senha == dto.Senha)
                .FirstOrDefault();

            if (usuarioAutenticado == null)
                return null;

            var permissoes = PermissaoRepository
                .List(p => p.IdGrupoDePermissao == usuarioAutenticado.IdGrupoDePermissao)
                .Select(p => p.Nome)
                .ToList();

            var usuarioViewModel = Mapper.Map<UsuarioViewModel>(usuarioAutenticado);
            usuarioViewModel.GrupoDePermissao.ConfigurarPermissoes(permissoes);

            return usuarioViewModel;
        }
        catch
        {
            return null;
        }
    }
}
