﻿using AutoMapper;
using CenedQualificando.Api.Services.Base;
using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Api.Services.Contracts;
using CenedQualificando.Domain.Interfaces.UoW;
using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Utils;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CenedQualificando.Api.Services
{
    public class AlunoService
        : BaseService<Aluno, AlunoDto, IAlunoQuery, IAlunoRepository>, IAlunoService
    {
        public AlunoService(
            IAlunoQuery query,
            IAlunoRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper) :
            base(query, repository, unitOfWork, mapper)
        {
        }

        public override IQueryable<Aluno> CriarConsulta()
        {
            return Repository.List().Include(x => x.Penitenciaria);
        }

        public async Task<IEnumerable<Aluno>> BuscarAlunosPorId(int[] idAlunos)
        {
            return await Repository.BuscarAlunosPorId(idAlunos);
        }

        public IEnumerable<SelectResult> ObterComboSelecao(string pesquisa, int quantidade = 10)
        {
            var selectList = new List<SelectResult>();

            var query = !string.IsNullOrEmpty(pesquisa)
                ? Repository.List(x => x.Nome.Contains(pesquisa) || x.Cpf == pesquisa)
                : Repository.List();

            query
                .Where(x => x.IdPenitenciaria > 1)
                .OrderBy(o => o.Nome)
                .Take(quantidade)
                .Select(s => new { 
                    s.IdAluno, 
                    s.Nome,
                    s.Cpf
                });

            var list = query.ToList();

            if (list.Any())
            {
                foreach (var item in list)
                {
                    selectList.Add(new SelectResult
                    {
                        Id = item.IdAluno,
                        Text = $"{item.Nome.ToUpper()} | CPF: {item.Cpf}"
                    });
                }
            }

            return selectList;
        }
    }
}
