using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Models.Entities;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class PenitenciariaQuery : IPenitenciariaQuery
    {
        public Expression<Func<Penitenciaria, bool>> FiltroGenerico(string textoFiltro)
        {
            return x => x.Nome.Contains(textoFiltro) || x.Cidade.Contains(textoFiltro);
        }

        public Expression<Func<Penitenciaria, object>> Ordenacao(string campo)
        {
            switch (campo)
            {
                case nameof(Penitenciaria.Uf):
                    return x => x.Uf;
                case nameof(Penitenciaria.Cidade):
                    return x => x.Cidade;
                default:
                    return x => x.Nome;
            }
        }
    }
}
