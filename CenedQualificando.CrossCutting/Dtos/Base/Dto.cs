using CenedQualificando.CrossCutting.Dtos.Base;
using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.CrossCutting.Dtos.Base
{
    public abstract class Dto<TEntity> : IDto
        where TEntity : Entity
    {
        public virtual int Id { get; set; }
    }
}