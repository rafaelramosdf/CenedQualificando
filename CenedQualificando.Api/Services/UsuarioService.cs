using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CenedQualificando.Api.Services.Base;
using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Interfaces.UoW;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Models.Utils;
using Microsoft.Extensions.Logging;

namespace CenedQualificando.Api.Services
{
    public class UsuarioService : BaseService<Usuario, UsuarioDto, UsuarioFilter, IUsuarioQuery, IUsuarioRepository>, IUsuarioService
    {
        private readonly IGrupoDePermissaoService _grupoDePermissaoService;

        public UsuarioService(
            IUsuarioQuery query,
            IUsuarioRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<UsuarioService> log, 
            IGrupoDePermissaoService grupoDePermissaoService) :
            base(query, repository, unitOfWork, mapper, log)
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


        public IEnumerable<SelectResult> ObterComboSelecao(string pesquisa, int quantidade = 50)
        {
            var selectList = new List<SelectResult>();

            var query = !string.IsNullOrEmpty(pesquisa)
                ? Repository.List(x => x.Nome.Contains(pesquisa) || x.Login == pesquisa)
                : Repository.List();

            query.Where(c => c.IdUsuario > 0).OrderBy(o => o.Nome)
                .Take(quantidade)
                .Select(s => new {
                    s.IdUsuario,
                    s.Nome,
                    s.Login,
                    s.CpfUsuario
                });

            var list = query.ToList();

            if (list.Any())
            {
                foreach (var item in list)
                {
                    selectList.Add(new SelectResult
                    {
                        Id = item.IdUsuario,
                        Text = $"{item.Nome.ToUpper()}"
                    });
                }
            }

            return selectList;
        }
    }
}
