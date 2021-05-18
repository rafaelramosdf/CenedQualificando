using System.ComponentModel.DataAnnotations.Schema;

namespace CenedQualificando.Domain.Models.Base
{
    public class Entity
    {
        [NotMapped]
        public virtual int Id { get; set; }
    }
}
