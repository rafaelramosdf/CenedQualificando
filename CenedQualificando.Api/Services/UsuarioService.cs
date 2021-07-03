using System.Threading.Tasks;
using AutoMapper;
using CenedQualificando.Api.Services.Base;
using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Interfaces.UoW;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Api.Services
{
    public class UsuarioService : BaseService<Usuario, UsuarioDto, IUsuarioQuery, IUsuarioRepository>, IUsuarioService
    {
        private readonly IGrupoDePermissaoService _grupoDePermissaoService;

        public UsuarioService(
            IUsuarioQuery query,
            IUsuarioRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IGrupoDePermissaoService grupoDePermissaoService) :
            base(query, repository, unitOfWork, mapper)
        {
            _grupoDePermissaoService = grupoDePermissaoService;
        }

        public async Task<UsuarioDto> Authenticate(string login, string senha)
        {
            var user = Mapper.Map<UsuarioDto>(await Repository.Authenticate(login, senha));
            if (user == null)
                return null;

            var grupoDePermissao = _grupoDePermissaoService.Buscar(user.IdGrupoDePermissao);
            if (grupoDePermissao != null)
            {
                user.GrupoDePermissao = grupoDePermissao;
            }

            return user;
        }
    }
}
