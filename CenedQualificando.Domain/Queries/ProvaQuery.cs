﻿using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Models.Entities;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class ProvaQuery : IProvaQuery
    {
        public Expression<Func<Prova, bool>> FiltroGenerico(string textoFiltro)
        {
            throw new NotImplementedException();
        }

        public Expression<Func<Prova, object>> Ordenacao(string campo)
        {
            throw new NotImplementedException();
        }
    }
}