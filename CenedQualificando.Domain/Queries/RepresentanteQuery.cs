﻿using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Queries.Contracts;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class RepresentanteQuery : IRepresentanteQuery
    {
        public Expression<Func<Representante, bool>> ObterPesquisa(RepresentanteFilter filtro)
        {
            if (string.IsNullOrEmpty(filtro?.Search))
                return _ => true;

            return x => x.Nome.Contains(filtro.Search);
        }

        public Expression<Func<Representante, object>> ObterOrdenacao(string campo)
        {
            switch (campo)
            {
                default:
                    return x => x.Nome;
            }
        }
    }
}
