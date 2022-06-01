using CenedQualificando.Domain.Extensions;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Enumerations;
using CenedQualificando.Domain.Models.Enumerations.Filters;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Queries.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class MatriculaQuery : IMatriculaQuery
    {
        public Expression<Func<Matricula, bool>> ObterPesquisa(MatriculaFilter filtro)
        {
            if (string.IsNullOrEmpty(filtro?.Search))
                return _ => true;

            return x =>
                (x.Aluno != null && x.Aluno.Nome != null && x.Aluno.Nome.Contains(filtro.Search)) ||
                (x.Aluno != null && x.Aluno.Cpf != null && x.Aluno.Cpf == filtro.Search) ||
                (x.Curso != null && x.Curso.Codigo != null && x.Curso.Codigo == filtro.Search) ||
                (x.Curso != null && x.Curso.Nome != null && x.Curso.Nome.Contains(filtro.Search));
        }

        public IQueryable<Matricula> FiltrarMatriculas(MatriculaFilter filtro, IQueryable<Matricula> queryList)
        {
            if (filtro != null) 
            {
                switch (filtro.TipoFiltroPersonalizado)
                {
                    case MatriculaFilterEnum.SomenteMatriculaSemDataInicio:
                        queryList = queryList.Where(m => !m.InicioCurso.PossuiValor());
                        break;

                    case MatriculaFilterEnum.SomenteMatriculaSemDataCertificadoExpedido:
                        queryList = queryList.Where(m => !m.CertificadoExpedido.PossuiValor());
                        break;

                    case MatriculaFilterEnum.SomenteMatriculaComProvaAutorizada:
                        var statusCurso = new List<int>
                    {
                        StatusCursoEnum.EmAndamento.ToInt32(),
                        StatusCursoEnum.NaoAprovado.ToInt32()
                    };
                        queryList = queryList.Where(m => statusCurso.Contains(m.StatusCurso));
                        break;
                    default:
                        break;
                }

                if (filtro.IdAluno > 0)
                    queryList = queryList.Where(x => x.IdAluno == filtro.IdAluno);

                if (filtro.IdPenitenciaria > 0)
                    queryList = queryList.Where(x => x.IdPenitenciaria == filtro.IdPenitenciaria);

                if (filtro.IdMatriculas.Any())
                    queryList = queryList.Where(x => filtro.IdMatriculas.Contains(x.IdMatricula));

                if (filtro.StatusCurso.Any())
                    queryList = queryList.Where(x => filtro.StatusCurso.Contains(x.StatusCurso));

                if (filtro.PeriodoDataMatricula.Inicio.HasValue)
                    queryList = queryList.Where(x => x.DataMatricula >= filtro.PeriodoDataMatricula.Inicio);
                if (filtro.PeriodoDataMatricula.Final.HasValue)
                    queryList = queryList.Where(x => x.DataMatricula <= filtro.PeriodoDataMatricula.Final);

                if (filtro.PeriodoDataPiso.Inicio.HasValue)
                    queryList = queryList.Where(x => x.DataPiso >= filtro.PeriodoDataPiso.Inicio);
                if (filtro.PeriodoDataPiso.Final.HasValue)
                    queryList = queryList.Where(x => x.DataPiso <= filtro.PeriodoDataPiso.Final);

                if (filtro.PeriodoDataCertificadoExpedido.Inicio.HasValue)
                    queryList = queryList.Where(x => x.CertificadoExpedido >= filtro.PeriodoDataCertificadoExpedido.Inicio);
                if (filtro.PeriodoDataCertificadoExpedido.Final.HasValue)
                    queryList = queryList.Where(x => x.CertificadoExpedido <= filtro.PeriodoDataCertificadoExpedido.Final);

                if (filtro.PeriodoDataProvaRecebida.Inicio.HasValue || filtro.PeriodoDataProvaRecebida.Final.HasValue)
                {
                    var dtInicioProvaRecebida = filtro.PeriodoDataProvaRecebida.Inicio ?? DateTime.MinValue;
                    var dtFinalProvaRecebida = filtro.PeriodoDataProvaRecebida.Final ?? DateTime.MaxValue;
                    queryList = queryList.Where(x => x.Provas.Where(p => p.DataRecebidaProva >= dtInicioProvaRecebida
                                                    && p.DataRecebidaProva <= dtFinalProvaRecebida).Any());
                }
            }

            return queryList;
        }

        public Expression<Func<Matricula, object>> ObterOrdenacao(string campo)
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
