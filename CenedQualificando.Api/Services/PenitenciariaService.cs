using AutoMapper;
using CenedQualificando.Api.Services.Base;
using CenedQualificando.Domain.Extensions;
using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Interfaces.UoW;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Enumerations;
using CenedQualificando.Domain.Models.Utils;
using System.Collections.Generic;
using System.Linq;

namespace CenedQualificando.Api.Services
{
    public class PenitenciariaService
        : BaseService<Penitenciaria, PenitenciariaDto, IPenitenciariaQuery, IPenitenciariaRepository>, IPenitenciariaService
    {
        public PenitenciariaService(
            IPenitenciariaQuery query,
            IPenitenciariaRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper) :
            base(query, repository, unitOfWork, mapper)
        {
        }

        public IEnumerable<SelectResult> ObterComboSelecao(string pesquisa, int quantidade = 10, int selecionado = 0)
        {
            var selectList = new List<SelectResult>();

            var query = !string.IsNullOrEmpty(pesquisa) 
                ? Repository.List(x => x.Nome.Contains(pesquisa)) 
                : Repository.List();

            query
                .Where(x => x.IdPenitenciaria > 1)
                .OrderBy(o => o.Nome)
                .Take(quantidade)
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

            if(selecionado > 0)
            {
                var entity = Repository.Get(selecionado);
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
}
