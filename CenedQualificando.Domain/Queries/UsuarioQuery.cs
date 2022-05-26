using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class UsuarioQuery : IUsuarioQuery
    {
        public Expression<Func<Usuario, bool>> Filtrar(UsuarioFilter filtro)
        {
            return x => x.Nome.Contains(filtro.Search) 
                || x.CpfUsuario == filtro.Search
                || x.Login.ToLower() == filtro.Search.ToLower() 
                || x.Email.ToLower() == filtro.Search.ToLower();
        }

        public Expression<Func<Usuario, object>> Ordenar(string campo)
        {
            switch (campo)
            {
                default:
                    return x => x.Nome;
            }
        }
    }
}
