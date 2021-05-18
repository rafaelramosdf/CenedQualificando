using System.Collections.Generic;
using System.Threading.Tasks;
using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Domain.Models;
using CenedQualificando.Infra.Context;
using CenedQualificando.Infra.Repository.Base;

namespace CenedQualificando.Infra.Repository
{
    public class GrupoDePermissaoRepository : BaseRepository<GrupoDePermissao>, IGrupoDePermissaoRepository
    {
        public GrupoDePermissaoRepository(EntityContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Permissao>> GetPermissoesAsync(int idGrupoPermissao)
        {
            return null;
            // TODO: Refazer com EntityFramework
            //return await Dapper.DapperConnection.QueryAsync<Permissao>($@"SELECT IdPermissao, Nome, IdGrupoDePermissao FROM Penitenciario.Permissao WHERE IdGrupoDePermissao = {idGrupoPermissao}");
        }
    }
}
