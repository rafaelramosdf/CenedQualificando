namespace CenedQualificando.Domain.Models.Base
{
    public abstract class Dto<TEntity> : IDto
        where TEntity : Entity
    {
        public virtual int Id { get; set; }
    }
}