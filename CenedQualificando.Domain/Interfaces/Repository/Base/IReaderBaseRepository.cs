using CenedQualificando.Domain.Models.Base;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Interfaces.Repository.Base
{
    public interface IReaderBaseRepository<TEntity> 
        where TEntity : Entity
    {
        IQueryable<TEntity> List();
        IQueryable<TEntity> List(Expression<Func<TEntity, bool>> query);
        TEntity Get(Expression<Func<TEntity, bool>> query);
        TEntity Get(int id);
    }
}
