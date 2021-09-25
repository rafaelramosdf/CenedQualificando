using System.Collections.Generic;
using System.Threading.Tasks;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Utils;

namespace CenedQualificando.Domain.Interfaces.Services
{
    public interface IUsuarioService : IBaseService<Usuario, UsuarioDto>
    {
        Task<UsuarioDto> Authenticate(string login, string senha);

        IEnumerable<SelectResult> ObterComboSelecao(string pesquisa, int quantidade = 50);
    }
}
