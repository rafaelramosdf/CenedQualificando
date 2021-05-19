using AutoMapper;
using CenedQualificando.Api.Services.Base;
using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Objects;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<FiscalSalaDto> Listar()
        {
            return _mapper.Map<IEnumerable<FiscalSala>, IEnumerable<FiscalSalaDto>>(_repository.List().ToList());
        }

        public DataTableModel<FiscalSalaDto> Listar(int page = 1, int limit = 10)
        {
            var lista = _repository.List()
                                   .Skip((page - 1) * limit)
                                   .Take(limit)
                                   .ToList();

            var dataTableModel = new DataTableModel<FiscalSalaDto>
            {
                Data = _mapper.Map<IEnumerable<FiscalSala>, IEnumerable<FiscalSalaDto>>(lista),
                Pagination = new DataTablePaginationModel
                {
                    Limit = limit,
                    Page = page,
                    Total = _repository.List().Count()
                }
            };

            return dataTableModel;
        }

        public DataTableModel<FiscalSalaDto> Listar(DataTableModel<FiscalSalaDto> dataTableModel)
        {
            IQueryable<FiscalSala> queryList = _repository.List();

            if (!string.IsNullOrEmpty(dataTableModel.Filter.Text))
            {
                var filterExpression = _query.FiltroGenerico(dataTableModel.Filter.Text);
                queryList = _repository.List(filterExpression);
            }

            var sortingExpression = _query.Ordenacao(dataTableModel.Sorting.Field);
            queryList = dataTableModel.Sorting.Desc ? queryList.OrderByDescending(sortingExpression) : queryList.OrderBy(sortingExpression);

            dataTableModel.Pagination.Total = queryList.Count();

            queryList = queryList
                .Skip((dataTableModel.Pagination.Page - 1) * dataTableModel.Pagination.Limit)
                .Take(dataTableModel.Pagination.Limit);

            dataTableModel.Data = _mapper.Map<IEnumerable<FiscalSala>, IEnumerable<FiscalSalaDto>>(queryList.ToList());

            return dataTableModel;
        }
    }
}
