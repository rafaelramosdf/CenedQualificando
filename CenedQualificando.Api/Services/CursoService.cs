using AutoMapper;
using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Domain.Interfaces.UoW;
using CenedQualificando.Api.Services.Base;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using CenedQualificando.Domain.Models.Utils;
using System.Linq;
using CenedQualificando.Domain.Models.Filters;

namespace CenedQualificando.Api.Services
{
    public class CursoService
        : BaseService<Curso, CursoDto, CursoFilter, ICursoQuery, ICursoRepository>, ICursoService
    {
        public CursoService(
            ICursoQuery query,
            ICursoRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<CursoService> log) :
            base(query, repository, unitOfWork, mapper, log)
        {
        }

        public IEnumerable<SelectResult> ObterComboSelecao(string pesquisa, int quantidade = 50)
        {
            var selectList = new List<SelectResult>();

            var query = !string.IsNullOrEmpty(pesquisa)
                ? Repository.List(x => x.Nome.Contains(pesquisa) || x.Codigo == pesquisa)
                : Repository.List();

            query.Where(c => c.IdCurso > 0).OrderBy(o => o.Nome)
                .Take(quantidade)
                .Select(s => new {
                    s.IdCurso,
                    s.Nome,
                    s.Codigo,
                    s.CargaHoraria,
                    s.ValorTotal
                });

            var list = query.ToList();

            if (list.Any())
            {
                foreach (var item in list)
                {
                    selectList.Add(new SelectResult
                    {
                        Id = item.IdCurso,
                        Text = $"{item.Codigo} - {item.Nome.ToUpper()} | C.H. {item.CargaHoraria} | VL {item.ValorTotal:c}"
                    });
                }
            }

            return selectList;
        }
    }
}
