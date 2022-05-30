using AutoMapper;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace CenedQualificando.Domain.Handlers.Usuario;

public interface IObterComboSelecaoUsuariosQueryHandler : ISelectQueryHandler
{
}

public class ObterComboSelecaoUsuariosQueryHandler : IObterComboSelecaoUsuariosQueryHandler
{
    private readonly ILogger<ObterComboSelecaoUsuariosQueryHandler> Logger;
    private readonly IUsuarioRepository Repository;
    private readonly IMapper Mapper;

    public ObterComboSelecaoUsuariosQueryHandler(
        IUsuarioRepository repository,
        IMapper mapper,
        ILogger<ObterComboSelecaoUsuariosQueryHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
    }

    public IEnumerable<SelectResult> Execute(string search, int limit, int selected = 0)
    {
        Logger.LogInformation($"Iniciando handler ObterComboSelecaoUsuariosQueryHandler");

        var selectList = new List<SelectResult>();

        var query = !string.IsNullOrEmpty(search)
            ? Repository.List(x => x.Nome.Contains(search) || x.CpfUsuario == search)
            : Repository.List();

        query
            .Where(x => x.IdUsuario > 0)
            .OrderBy(o => o.Nome)
            .Take(limit)
            .Select(s => new
            {
                s.IdUsuario,
                s.Nome,
                s.CpfUsuario
            });

        var list = query.ToList();

        if (list.Any())
        {
            foreach (var item in list)
            {
                selectList.Add(new SelectResult
                {
                    Id = item.IdUsuario,
                    Text = $"{item.Nome.ToUpper()} | CPF: {item.CpfUsuario}"
                });
            }
        }

        if (selected > 0 && !selectList.Any(a => a.Id == selected))
        {
            var entity = Repository.Get(selected);
            selectList.Add(new SelectResult
            {
                Id = entity.Id,
                Text = $"{entity.Nome.ToUpper()} | CPF: {entity.CpfUsuario}"
            });

            selectList = selectList.OrderBy(o => o.Text).ToList();
        }

        return selectList;
    }
}
