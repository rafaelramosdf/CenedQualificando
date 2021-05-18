using AutoMapper;
using CenedQualificando.Api.Models;
using CenedQualificando.Api.Models.Base;
using CenedQualificando.Api.Services.Base;
using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CenedQualificando.Api.Services
{
    public class FiscalSalaService : IFiscalSalaService
    {
        private readonly IFiscalSalaRepository _repository;
        private readonly IFiscalSalaQuery _query;
        private readonly IMapper _mapper;

        public FiscalSalaService(IFiscalSalaRepository repository,
            IFiscalSalaQuery query,
            IMapper mapper)
        {
            _repository = repository;
            _query = query;
            _mapper = mapper;
        }

        public IEnumerable<FiscalSalaModel> Listar()
        {
            return _mapper.Map<IEnumerable<FiscalSala>, IEnumerable<FiscalSalaModel>>(_repository.List().ToList());
        }

        public DataTableModel<FiscalSalaModel> Listar(int page = 1, int limit = 10)
        {
            var lista = _repository.List()
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToList();

            var dataTableModel = new DataTableModel<FiscalSalaModel>
            {
                Data = _mapper.Map<IEnumerable<FiscalSala>, IEnumerable<FiscalSalaModel>>(lista),
                Pagination = new DataTablePaginationModel
                {
                    Limit = limit,
                    Page = page,
                    Total = _repository.List().Count()
                }
            };

            return dataTableModel;
        }

        public DataTableModel<FiscalSalaModel> Listar(DataTableModel<FiscalSalaModel> dataTableModel)
        {
            IQueryable<FiscalSala> queryList = _repository.List();

            if (!string.IsNullOrEmpty(dataTableModel.Filter.Text))
            {
                var filterExpression = _query.ObterFiltroGenerico(dataTableModel.Filter.Text);
                queryList = _repository.List(filterExpression);
            }

            var sortingExpression = _query.ObterOrdenacao(dataTableModel.Sorting.Field);
            queryList = dataTableModel.Sorting.Desc ? queryList.OrderByDescending(sortingExpression) : queryList.OrderBy(sortingExpression);

            dataTableModel.Pagination.Total = queryList.Count();

            queryList = queryList
                .Skip((dataTableModel.Pagination.Page - 1) * dataTableModel.Pagination.Limit)
                .Take(dataTableModel.Pagination.Limit);

            dataTableModel.Data = _mapper.Map<IEnumerable<FiscalSala>, IEnumerable<FiscalSalaModel>>(queryList.ToList());

            return dataTableModel;
        }
    }
}
