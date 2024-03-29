﻿using CenedQualificando.Domain.Extensions;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Queries.Contracts;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class AlunoQuery : IAlunoQuery
    {
        public static Expression<Func<Aluno, bool>> ObterAlunoPorCpf(string cpf)
        {
            return x => x.Cpf == cpf;
        }

        public Expression<Func<Aluno, bool>> ObterPesquisa(AlunoFilter filtro)
        {
            Expression<Func<Aluno, bool>> query = _ => true;

            if (filtro != null)
            {
                if (!string.IsNullOrEmpty(filtro.Search))
                {
                    query = x => x.Nome.Contains(filtro.Search) ||
                            x.Cpf == filtro.Search ||
                            x.NomePreposto.Contains(filtro.Search) ||
                            x.CpfPreposto == filtro.Search;
                }
                else if (filtro.IdPenitenciaria.PossuiValor() && filtro.Cpf.PossuiValor())
                {
                    query = x => x.IdPenitenciaria == filtro.IdPenitenciaria &&
                    (x.Cpf == filtro.Cpf || x.CpfPreposto == filtro.Cpf);
                }
                else
                {
                    if (filtro.IdPenitenciaria.PossuiValor())
                    {
                        query = x => x.IdPenitenciaria == filtro.IdPenitenciaria;
                    }
                    else if (filtro.Cpf.PossuiValor())
                    {
                        query = x => x.Cpf == filtro.Cpf || x.CpfPreposto == filtro.Cpf;
                    }
                }
            }

            return query;
        }

        public Expression<Func<Aluno, object>> ObterOrdenacao(string campo)
        {
            switch (campo)
            {
                case nameof(Aluno.NomePreposto):
                    return x => x.NomePreposto;
                default:
                    return x => x.Nome;
            }
        }
    }
}