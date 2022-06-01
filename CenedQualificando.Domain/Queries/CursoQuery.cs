using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Queries.Contracts;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class CursoQuery : ICursoQuery
    {
        public Expression<Func<Curso, bool>> ObterPesquisa(CursoFilter filtro)
        {
            return x => x.Codigo == filtro.Search || x.Nome.Contains(filtro.Search);
        }

        public Expression<Func<Curso, object>> ObterOrdenacao(string campo)
        {
            switch (campo)
            {
                case nameof(Curso.Codigo):
                    return x => Convert.ToDecimal(x.Codigo);
                default:
                    return x => x.Nome;
            }
        }
    }
}
