using System.Threading.Tasks;
using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Api.Services.Contracts
{
    public interface IUsuarioService : IBaseService<Usuario, UsuarioDto>
    {
        Task<UsuarioDto> Authenticate(string login, string senha);
    }
}
