using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Models.Entities;
using System;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class MatriculaQuery : IMatriculaQuery
    {
        public Expression<Func<Matricula, bool>> FiltroGenerico(string textoFiltro)
        {
            return x => x.NumeroMatricula.Contains(textoFiltro) ||
                (x.Aluno != null && x.Aluno.Nome.Contains(textoFiltro)) ||
                (x.Curso != null && x.Curso.Codigo.Contains(textoFiltro)) ||
                (x.Curso != null && x.Curso.Nome.Contains(textoFiltro));
        }

        public Expression<Func<Matricula, object>> Ordenacao(string campo)
        {
            switch (campo)
            {
                case nameof(Matricula.Aluno):
                    return x => x.Aluno.Nome;
                case nameof(Matricula.Curso):
                    return x => x.Curso.Nome;
                default:
                    return x => x.NumeroMatricula;
            }
        }
    }
}
