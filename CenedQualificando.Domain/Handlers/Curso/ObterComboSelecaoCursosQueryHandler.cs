using AutoMapper;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace CenedQualificando.Domain.Handlers.Curso;

public interface IObterComboSelecaoCursosQueryHandler : ISelectQueryHandler
{
}

public class ObterComboSelecaoCursosQueryHandler : IObterComboSelecaoCursosQueryHandler
{
    private readonly ILogger<ObterComboSelecaoCursosQueryHandler> Logger;
    private readonly ICursoRepository Repository;
    private readonly IMapper Mapper;

    public ObterComboSelecaoCursosQueryHandler(
        ICursoRepository repository,
        IMapper mapper,
        ILogger<ObterComboSelecaoCursosQueryHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
    }

    public IEnumerable<SelectResult> Execute(string search, int limit, int selected = 0)
    {
        Logger.LogInformation($"Iniciando handler ObterComboSelecaoCursosQueryHandler");

        var selectList = new List<SelectResult>();

        var query = !string.IsNullOrEmpty(search)
            ? Repository.List(x => x.Nome.Contains(search) || x.Codigo == search)
            : Repository.List();

        query.Where(c => c.IdCurso > 0).OrderBy(o => o.Nome)
            .Take(limit)
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

        if (selected > 0 && !selectList.Any(a => a.Id == selected))
        {
            var entity = Repository.Get(selected);
            selectList.Add(new SelectResult
            {
                Id = entity.Id,
                Text = $"{entity.Codigo} - {entity.Nome.ToUpper()} | C.H. {entity.CargaHoraria} | VL {entity.ValorTotal:c}"
            });

            selectList = selectList.OrderBy(o => o.Text).ToList();
        }

        return selectList;
    }
}
