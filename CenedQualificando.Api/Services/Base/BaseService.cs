using AutoMapper;
using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Interfaces.Repository.Base;
using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Interfaces.UoW;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Objects;
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

        public virtual TDto Buscar(int id)
        {
            return Mapper.Map<TDto>(Repository.Get(id));
        }

        public virtual DataTableModel<TDto> Buscar(DataTableModel<TDto> dataTableModel)
        {
            return GerarDataTable(dataTableModel);
        }

        protected DataTableModel<TDto> GerarDataTable(DataTableModel<TDto> dataTableModel, IQueryable<TEntity> query = null)
        {
            IQueryable<TEntity> queryList = query != null ? query : Repository.List();

            Expression<Func<TEntity, bool>> filterExpression = null;

            if (!string.IsNullOrEmpty(dataTableModel.Filter.Text))
            {
                filterExpression = Query.FiltroGenerico(dataTableModel.Filter.Text);
                queryList = queryList.Where(filterExpression);
            }

            dataTableModel.Pagination.Total = filterExpression != null 
                ? Repository.List(filterExpression).Count() 
                : Repository.List().Count();

            var sortingExpression = Query.Ordenacao(dataTableModel.Sorting.Field);
            queryList = dataTableModel.Sorting.Desc ? queryList.OrderByDescending(sortingExpression) : queryList.OrderBy(sortingExpression);

            queryList = queryList
                .Skip((dataTableModel.Pagination.Page - 1) * dataTableModel.Pagination.Limit)
                .Take(dataTableModel.Pagination.Limit);

            dataTableModel.Data = Mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(queryList.ToList());

            return dataTableModel;
        }
    }
}
