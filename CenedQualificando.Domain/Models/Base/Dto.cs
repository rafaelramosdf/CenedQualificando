using Flunt.Validations;

namespace CenedQualificando.Domain.Models.Base
{
    public abstract class Dto<TEntity> : Contract<TEntity>, IDto
        where TEntity : Entity
    {
        public virtual int Id { get; set; }

        public virtual void Validate()
        {
            // Implementar na classe filha
        }
    }
}