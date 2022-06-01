using System.Collections.Generic;
using System.Threading.Tasks;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Domain.Interfaces.Services
{
    public interface IUsuarioService : IBaseService<Usuario, UsuarioViewModel, UsuarioFilter>
    {
        Task<UsuarioViewModel> Authenticate(string login, string senha);

        IEnumerable<SelectResult> ObterComboSelecao(string pesquisa, int quantidade = 50);
    }
}
