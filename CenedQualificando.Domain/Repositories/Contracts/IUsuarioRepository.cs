using System.Threading.Tasks;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Repositories.Base;

namespace CenedQualificando.Domain.Repositories.Contracts
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario> Authenticate(string login, string senha);
    }
}
