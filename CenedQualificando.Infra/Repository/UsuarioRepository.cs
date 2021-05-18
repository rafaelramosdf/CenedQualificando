using System.Threading.Tasks;
using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Domain.Models;
using CenedQualificando.Infra.Context;
using CenedQualificando.Infra.Repository.Base;

namespace CenedQualificando.Infra.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(EntityContext context)
            : base(context)
        {
        }

        public async Task<Usuario> Authenticate(string login, string senha)
        {
            return null;
            // TODO: Refazer com EntityFramework
            //var query = $@"{GetSelectStatement(null, null, $@"WHERE Usuario.Login = '{login}' AND Usuario.Senha = '{senha}'")}";
            //return await Dapper.DapperConnection.QueryFirstOrDefaultAsync<Usuario>(query);
        }
    }
}
