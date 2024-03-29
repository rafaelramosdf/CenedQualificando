﻿using CenedQualificando.Domain.Extensions;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Enumerations;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Queries.Contracts;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class PenitenciariaQuery : IPenitenciariaQuery
    {
        public Expression<Func<Penitenciaria, bool>> ObterPesquisa(PenitenciariaFilter filtro)
        {
            if (string.IsNullOrEmpty(filtro?.Search))
                return _ => true;

            var ufs = Enum.GetNames(typeof(UfEnum)).Select(s => s.ToUpper()).ToList();
            var filtroUf = ufs.Contains(filtro.Search.ToUpper()) ? filtro.Search.DescriptionTo<UfEnum>() : UfEnum.Null;

            return filtroUf != UfEnum.Null  
                ? x => x.Uf == (int)filtroUf
                : x => x.Nome.Contains(filtro.Search) || x.Cidade.Contains(filtro.Search);
        }

        public Expression<Func<Penitenciaria, object>> ObterOrdenacao(string campo)
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

        public IQueryable<Penitenciaria> FiltrarPenitenciarias(PenitenciariaFilter filtro, IQueryable<Penitenciaria> queryList)
        {
            if (filtro != null) 
            {
                if (filtro.Uf != UfEnum.Null)
                    queryList = queryList.Where(p => p.Uf == (int)filtro.Uf);
            }

            return queryList;
        }
    }
}
