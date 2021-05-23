using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Models.Entities;
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

        public Expression<Func<Aluno, bool>> FiltroGenerico(string textoFiltro)
        {
            return x => x.Nome.Contains(textoFiltro) || 
                x.Cpf == textoFiltro ||
                x.NomePreposto.Contains(textoFiltro) || 
                x.CpfPreposto == textoFiltro;
        }

        public Expression<Func<Aluno, object>> Ordenacao(string campo)
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
