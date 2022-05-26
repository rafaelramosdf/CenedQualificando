﻿using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class CursoQuery : ICursoQuery
    {
        public Expression<Func<Curso, bool>> Filtrar(CursoFilter filtro)
        {
            return x => x.Codigo == filtro.Search || x.Nome.Contains(filtro.Search);
        }

        public Expression<Func<Curso, object>> Ordenar(string campo)
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
