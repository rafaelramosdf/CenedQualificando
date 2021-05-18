using System.Threading.Tasks;
using CenedQualificando.Domain.Interfaces.Repository.Base;
using CenedQualificando.Domain.Models;

namespace CenedQualificando.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario> Authenticate(string login, string senha);
    }
}
