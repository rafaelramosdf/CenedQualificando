using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Domain.Interfaces.Repository.Base
{
    public interface IBaseRepository<TEntity> : IWriterBaseRepository<TEntity>, IReaderBaseRepository<TEntity> 
        where TEntity : Entity
    {
    }
}
