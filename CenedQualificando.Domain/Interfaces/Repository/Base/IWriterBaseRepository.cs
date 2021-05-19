using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Interfaces.Repository.Base
{
    public interface IWriterBaseRepository<TEntity> : IDisposable
        where TEntity : Entity
    {
        void Add(TEntity obj);
        void Add(IEnumerable<TEntity> objList);
        void Update(TEntity obj);
        void Update(IEnumerable<TEntity> objList);
        void Remove(TEntity obj);
        void Remove(IEnumerable<TEntity> objList);
        void Attach(TEntity obj);
        void Attach(IEnumerable<TEntity> objList);
    }
}
