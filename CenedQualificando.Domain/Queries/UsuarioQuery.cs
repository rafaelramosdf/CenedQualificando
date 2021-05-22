using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Models.Entities;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class UsuarioQuery : IUsuarioQuery
    {
        public Expression<Func<Usuario, bool>> FiltroGenerico(string textoFiltro)
        {
            return x => x.Nome.Contains(textoFiltro) 
                || x.CpfUsuario == textoFiltro 
                || x.Login.ToLower() == textoFiltro.ToLower() 
                || x.Email.ToLower() == textoFiltro.ToLower();
        }

        public Expression<Func<Usuario, object>> Ordenacao(string campo)
        {
            switch (campo)
            {
                default:
                    return x => x.Nome;
            }
        }
    }
}
