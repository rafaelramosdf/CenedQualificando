using AutoMapper;
using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Interfaces.Repository.Base;
using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Interfaces.UoW;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Utils;
using CenedQualificando.Domain.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CenedQualificando.Api.Services.Base
{
    public abstract class BaseService<TEntity, TDto, TFilter, TQuery, TRepository> : IBaseService<TEntity, TDto, TFilter>
        where TEntity : Entity, new()
        where TDto : IDto, new()
        where TFilter : Filter, new()
        where TQuery : IBaseQuery<TEntity, TFilter>
        where TRepository : IBaseRepository<TEntity>
    {
        protected readonly TQuery Query;
        protected readonly TRepository Repository;
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;
        protected readonly ILogger<IBaseService<TEntity, TDto, TFilter>> Log;

        protected BaseService(
            TQuery query,
            TRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<IBaseService<TEntity, TDto, TFilter>> log)
        {
            Query = query;
            UnitOfWork = unitOfWork;
            Mapper = mapper;
            Repository = repository;
            Log = log;
        }

        public virtual CommandResult Incluir(TDto vm)
        {
            try
            {
                var entity = Mapper.Map<TEntity>(vm);
                Repository.Add(entity);
                UnitOfWork.Commit();
                return new CommandResult(StatusCodes.Status200OK, Mapper.Map<TDto>(entity));
            }
            catch (Exception ex)
            {
                return RetornarErroPersistencia(ex, vm);
            }
        }
        public CommandResult Incluir(IEnumerable<TDto> vmList)
        {
            try
            {
                UnitOfWork.BeginTransaction();

                foreach (var item in vmList)
                {
                    Incluir(item);
                }

                UnitOfWork.CommitTransaction();

                return new CommandResult(StatusCodes.Status200OK, vmList);
            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback();
                return RetornarErroPersistencia(ex, vmList);
            }
        }

        public virtual CommandResult Alterar(TDto vm)
        {
            try
            {
                var entity = Mapper.Map<TEntity>(vm);
                Repository.Update(entity);
                UnitOfWork.Commit();
                return new CommandResult(StatusCodes.Status204NoContent, null);
            }
            catch (Exception ex)
            {
                return RetornarErroPersistencia(ex, vm);
            }
        }
        public CommandResult Alterar(IEnumerable<TDto> vmList)
        {
            try
            {
                UnitOfWork.BeginTransaction();

                foreach (var item in vmList)
                {
                    Alterar(item);
                }

                UnitOfWork.CommitTransaction();

                return new CommandResult(StatusCodes.Status204NoContent, null);
            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback();
                return RetornarErroPersistencia(ex, vmList);
            }
        }

        public virtual CommandResult Excluir(int id)
        {
            try
            {
                Repository.Remove(Repository.Get(id));
                UnitOfWork.Commit();
                return new CommandResult(StatusCodes.Status204NoContent, null);
            }
            catch (Exception ex)
            {
                return RetornarErroPersistencia(ex);
            }
        }
        public CommandResult Excluir(IEnumerable<int> idList)
        {
            try
            {
                UnitOfWork.BeginTransaction();

                foreach (var id in idList)
                {
                    Excluir(id);
                }

                UnitOfWork.CommitTransaction();

                return new CommandResult(StatusCodes.Status204NoContent, null);
            }
            catch (Exception ex)
            {
                UnitOfWork.Rollback();
                return RetornarErroPersistencia(ex);
            }
        }

        protected CommandResult RetornarErroPersistencia(Exception ex = null, object dto = null)
        {
            var log = $"\n\r" +
                $"***** [MESSAGE] *****\n\r" +
                $"{ex.Message}\n\r\n\r" +
                $"***** [INNER EXCEPTION] *****\n\r" +
                $"{ex.InnerException?.Message}\n\r";

            if (dto != null)
                log += $"\n\r" +
                    $"***** [DADOS DA REQUISICAO] ***** \n\r " +
                    $"{JsonConvert.SerializeObject(dto)}\n\r\n\r";

            Log.LogError(log);

            var commandResult = new CommandResult(StatusCodes.Status500InternalServerError, dto);
            commandResult.SetError(ErrorMessageResource.ErroPersistencia);
            return commandResult;
        }

        public TDto Buscar(int id)
        {
            return Mapper.Map<TDto>(Repository.Get(id));
        }

        public DataTableModel<TDto> Buscar(TFilter filtro)
        {
            var dataTableModel = new DataTableModel<TDto>();

            IQueryable<TEntity> queryList = CriarConsulta();

            Expression<Func<TEntity, bool>> filterExpression = filtro != null
                ? Query.Filtrar(filtro) : null;

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

        public IQueryable<TEntity> FiltrarConsulta(IQueryable<TEntity> queryList, Expression<Func<TEntity, bool>> filterExpression = null)
        {
            if (filterExpression != null)
                queryList = queryList.Where(filterExpression);

            return queryList;
        }

        public IQueryable<TEntity> OrdenarConsulta(IQueryable<TEntity> queryList, DataTableSortingModel sortingModel)
        {
            var sortingExpression = Query.Ordenar(sortingModel.Field);
            queryList = sortingModel.Desc ? queryList.OrderByDescending(sortingExpression) : queryList.OrderBy(sortingExpression);
            return queryList;
        }

        public IQueryable<TEntity> PaginarConsulta(IQueryable<TEntity> queryList, DataTablePaginationModel paginationModel)
        {
            return queryList.Skip((paginationModel.Page - 1) * paginationModel.Limit).Take(paginationModel.Limit);
        }
    }
}
