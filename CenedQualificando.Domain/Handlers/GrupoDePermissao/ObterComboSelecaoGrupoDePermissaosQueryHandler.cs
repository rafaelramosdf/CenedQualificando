using AutoMapper;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace CenedQualificando.Domain.Handlers.GrupoDePermissao;

public interface IObterComboSelecaoGrupoDePermissaosQueryHandler : ISelectQueryHandler
{
}

public class ObterComboSelecaoGrupoDePermissaosQueryHandler : IObterComboSelecaoGrupoDePermissaosQueryHandler
{
    private readonly ILogger<ObterComboSelecaoGrupoDePermissaosQueryHandler> Logger;
    private readonly IGrupoDePermissaoRepository Repository;
    private readonly IMapper Mapper;

    public ObterComboSelecaoGrupoDePermissaosQueryHandler(
        IGrupoDePermissaoRepository repository,
        IMapper mapper,
        ILogger<ObterComboSelecaoGrupoDePermissaosQueryHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
    }

    public IEnumerable<SelectResult> Execute(string search, int limit = 50, int selected = 0)
    {
        Logger.LogInformation($"Iniciando handler ObterComboSelecaoGrupoDePermissaosQueryHandler");

        var selectList = new List<SelectResult>();

        var query = !string.IsNullOrEmpty(search)
            ? Repository.List(x => x.Descricao.Contains(search))
            : Repository.List();

        var list = query
            .Where(x => true)
            .OrderBy(o => o.Descricao)
            .Take(limit)
            .Select(s => new
            {
                s.IdGrupoDePermissao,
                s.Descricao
            }).ToList();

        if (list.Any())
        {
            foreach (var item in list)
            {
                selectList.Add(new SelectResult
                {
                    Id = item.IdGrupoDePermissao,
                    Text = $"{item.Descricao.ToUpper()}"
                });
            }
        }

        if (selected > 0 && !selectList.Any(a => a.Id == selected))
        {
            var entity = Repository.Get(selected);
            selectList.Add(new SelectResult
            {
                Id = entity.Id,
                Text = $"{entity.Descricao.ToUpper()}"
            });

            selectList = selectList.OrderBy(o => o.Text).ToList();
        }

        return selectList;
    }
}
