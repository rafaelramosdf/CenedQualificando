using AutoMapper;
using CenedQualificando.Domain.Extensions;
using CenedQualificando.Domain.Models.Enumerations;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace CenedQualificando.Domain.Handlers.Penitenciaria;

public interface IObterComboSelecaoPenitenciariasQueryHandler : ISelectQueryHandler
{
}

public class ObterComboSelecaoPenitenciariasQueryHandler : IObterComboSelecaoPenitenciariasQueryHandler
{
    private readonly ILogger<ObterComboSelecaoPenitenciariasQueryHandler> Logger;
    private readonly IPenitenciariaRepository Repository;
    private readonly IMapper Mapper;

    public ObterComboSelecaoPenitenciariasQueryHandler(
        IPenitenciariaRepository repository,
        IMapper mapper,
        ILogger<ObterComboSelecaoPenitenciariasQueryHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
    }

    public IEnumerable<SelectResult> Execute(string search, int limit, int selected = 0)
    {
        Logger.LogInformation($"Iniciando handler ObterComboSelecaoPenitenciariasQueryHandler");

        var selectList = new List<SelectResult>();

        var query = !string.IsNullOrEmpty(search)
            ? Repository.List(x => x.Nome.Contains(search))
            : Repository.List();

        query
            .Where(x => x.IdPenitenciaria > 1)
            .OrderBy(o => o.Nome)
            .Take(limit)
            .Select(s => new {
                s.IdPenitenciaria,
                s.Nome,
                s.Uf
            });

        var list = query.ToList();

        if (list.Any())
        {
            foreach (var item in list)
            {
                selectList.Add(new SelectResult
                {
                    Id = item.Id,
                    Text = $"{item.Nome} | {((UfEnum)item.Uf).EnumDescription()}"
                });
            }
        }

        if (selected > 0 && !selectList.Any(a => a.Id == selected))
        {
            var entity = Repository.Get(selected);
            selectList.Add(new SelectResult
            {
                Id = entity.Id,
                Text = $"{entity.Nome} | {((UfEnum)entity.Uf).EnumDescription()}"
            });

            selectList = selectList.OrderBy(o => o.Text).ToList();
        }

        return selectList;
    }
}
