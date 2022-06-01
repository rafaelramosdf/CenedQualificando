using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Queries.Contracts;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class UsuarioQuery : IUsuarioQuery
    {
        public Expression<Func<Usuario, bool>> ObterPesquisa(UsuarioFilter filtro)
        {
            if (string.IsNullOrEmpty(filtro?.Search))
                return _ => true;

            return x => x.Nome.Contains(filtro.Search) 
                || x.CpfUsuario == filtro.Search
                || x.Login.ToLower() == filtro.Search.ToLower() 
                || x.Email.ToLower() == filtro.Search.ToLower();
        }

        public Expression<Func<Usuario, object>> ObterOrdenacao(string campo)
        {
            switch (campo)
            {
                default:
                    return x => x.Nome;
            }
        }
    }
}
