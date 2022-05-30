﻿using CenedQualificando.Domain.Extensions;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Enumerations;
using CenedQualificando.Domain.Models.Enumerations.Filters;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Queries.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class MatriculaQuery : IMatriculaQuery
    {
        public Expression<Func<Matricula, bool>> Filtrar(MatriculaFilter filtro)
        {
            if (string.IsNullOrEmpty(filtro?.Search))
                return _ => true;

            return x =>
                (x.Aluno != null && x.Aluno.Nome != null && x.Aluno.Nome.Contains(filtro.Search)) ||
                (x.Aluno != null && x.Aluno.Cpf != null && x.Aluno.Cpf == filtro.Search) ||
                (x.Curso != null && x.Curso.Codigo != null && x.Curso.Codigo == filtro.Search) ||
                (x.Curso != null && x.Curso.Nome != null && x.Curso.Nome.Contains(filtro.Search));
        }

        public Expression<Func<Matricula, bool>> FiltrarPelaSituacaoDaMatricula(MatriculaFilterEnum tipoFiltro)
        {
            switch (tipoFiltro)
            {
                case MatriculaFilterEnum.Null:
                    return x => true;

                case MatriculaFilterEnum.SomenteMatriculaSemDataInicio:
                    return x => true;

                case MatriculaFilterEnum.SomenteMatriculaSemDataCertificadoExpedido:
                    return x => true;

                case MatriculaFilterEnum.SomenteMatriculaComProvaAutorizada:
                    var statusCurso = new List<int>
                    {
                        StatusCursoEnum.EmAndamento.ToInt32(),
                        StatusCursoEnum.NaoAprovado.ToInt32()
                    };
                    return (x => statusCurso.Contains(x.StatusCurso));

                default:
                    return x => true;
            }
        }

        public Expression<Func<Matricula, object>> Ordenar(string campo)
        {
            switch (campo)
            {
                case nameof(Matricula.Aluno):
                    return x => x.Aluno.Nome;
                case nameof(Matricula.Curso):
                    return x => x.Curso.Nome;
                case nameof(Matricula.DataPiso):
                    return x => x.DataPiso;
                default:
                    return x => x.DataMatricula;
            }
        }
    }
}
