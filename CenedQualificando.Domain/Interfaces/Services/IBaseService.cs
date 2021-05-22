using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Objects;

namespace CenedQualificando.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity, TDto>
        where TEntity : Entity
        where TDto : IDto
    {
        TDto Buscar(int id);
        DataTableModel<TDto> Buscar(DataTableModel<TDto> dataTableModel);
        TDto Incluir(TDto vm);
        void Alterar(TDto vm);
        void Excluir(TDto vm);
    }
}
