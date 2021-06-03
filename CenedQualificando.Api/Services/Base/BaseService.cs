using AutoMapper;
using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Interfaces.Repository.Base;
using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Interfaces.UoW;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CenedQualificando.Api.Services.Base
{
    public abstract class BaseService<TEntity, TDto, TQuery, TRepository> : IBaseService<TEntity, TDto>
        where TEntity : Entity, new()
        where TDto : IDto, new()
        where TQuery : IBaseQuery<TEntity>
        where TRepository : IBaseRepository<TEntity>
    {
        protected readonly TQuery Query;
        protected readonly TRepository Repository;
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;

        protected BaseService(
            TQuery query,
            TRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            Query = query;
            UnitOfWork = unitOfWork;
            Mapper = mapper;
            Repository = repository;
        }

        public virtual TDto Incluir(TDto vm)
        {
            var entity = Mapper.Map<TEntity>(vm);
            Repository.Add(entity);
            UnitOfWork.Commit();
            return Mapper.Map<TDto>(entity);
        }
        public IEnumerable<TDto> Incluir(IEnumerable<TDto> vm)
        {
            try
            {
                UnitOfWork.BeginTransaction();
                foreach (var item in vm)
                {
                    Incluir(item);
                }
                UnitOfWork.CommitTransaction();
                return vm;
            }
            catch (System.Exception)
            {
                UnitOfWork.Rollback();
                throw;
            }
        }

        public virtual void Alterar(TDto vm)
        {
            var entity = Mapper.Map<TEntity>(vm);
            Repository.Update(entity);
            UnitOfWork.Commit();
        }
        public void Alterar(IEnumerable<TDto> vm)
        {
            try
            {
                UnitOfWork.BeginTransaction();
                foreach (var item in vm)
                {
                    Alterar(item);
                }
                UnitOfWork.CommitTransaction();
            }
            catch (System.Exception)
            {
                UnitOfWork.Rollback();
                throw;
            }
        }

        public virtual void Excluir(TDto vm)
        {
            Repository.Remove(Mapper.Map<TEntity>(vm));
            UnitOfWork.Commit();
        }
        public void Excluir(IEnumerable<TDto> vm)
        {
            try
            {
                UnitOfWork.BeginTransaction();
                foreach (var item in vm)
                {
                    Excluir(item);
                }
                UnitOfWork.CommitTransaction();
            }
            catch (System.Exception)
            {
                UnitOfWork.Rollback();
                throw;
            }
        }

        public TDto Buscar(int id)
        {
            return Mapper.Map<TDto>(Repository.Get(id));
        }

        public DataTableModel<TDto> Buscar(DataTableModel<TDto> dataTableModel)
        {
            return GerarDataTable(dataTableModel);
        }

        protected DataTableModel<TDto> GerarDataTable(DataTableModel<TDto> dataTableModel)
        {
            IQueryable<TEntity> queryList = CriarConsulta();

            Expression<Func<TEntity, bool>> filterExpression = !string.IsNullOrEmpty(dataTableModel.Filter.Text) 
                ? Query.FiltroGenerico(dataTableModel.Filter.Text) 
                : null;

            dataTableModel.Pagination.Total = filterExpression != null
                ? Repository.List(filterExpression).Count()
                : Repository.List().Count();

            queryList = FiltrarConsulta(queryList, filterExpression);

            queryList = OrdenarConsulta(queryList, dataTableModel.Sorting);

            queryList = PaginarConsulta(queryList, dataTableModel.Pagination);

            dataTableModel.Data = Mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(queryList.ToList());

            return dataTableModel;
        }

        public virtual IQueryable<TEntity> CriarConsulta()
        {
            return Repository.List();
        }

        public virtual IQueryable<TEntity> FiltrarConsulta(IQueryable<TEntity> queryList, Expression<Func<TEntity, bool>> filterExpression = null)
        {
            if (filterExpression != null)
                queryList = queryList.Where(filterExpression);

            return queryList;
        }

        public virtual IQueryable<TEntity> OrdenarConsulta(IQueryable<TEntity> queryList, DataTableSortingModel<TDto> sortingModel)
        {
            var sortingExpression = Query.Ordenacao(sortingModel.Field);
            queryList = sortingModel.Desc ? queryList.OrderByDescending(sortingExpression) : queryList.OrderBy(sortingExpression);
            return queryList;
        }

        public virtual IQueryable<TEntity> PaginarConsulta(IQueryable<TEntity> queryList, DataTablePaginationModel paginationModel)
        {
            return queryList.Skip((paginationModel.Page - 1) * paginationModel.Limit).Take(paginationModel.Limit);
        }
    }
}
