using CenedQualificando.Domain.Models.Base;
using System;

namespace CenedQualificando.Domain.Interfaces.Repository.Base
{
    public interface IWriterBaseRepository<TEntity> : IDisposable 
        where TEntity : Entity
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Attach(TEntity obj);
    }
}
