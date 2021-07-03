using System.Threading.Tasks;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Interfaces.Services
{
    public interface IUsuarioService : IBaseService<Usuario, UsuarioDto>
    {
        Task<UsuarioDto> Authenticate(string login, string senha);
    }
}
