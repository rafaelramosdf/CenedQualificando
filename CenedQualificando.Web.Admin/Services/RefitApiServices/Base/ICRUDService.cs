using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Utils;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.RefitApiServices.Base
{
    public interface ICRUDService<TEntity, TDto>
        where TEntity : Entity
        where TDto : Dto<TEntity>
    {
        [Post("")]
        Task<CommandResult> Incluir([Body] TDto model);

        [Put("/{id}")]
        Task<CommandResult> Alterar([AliasAs("id")] int id, [Body] TDto model);

        [Delete("/{id}")]
        Task<CommandResult> Excluir([AliasAs("id")] int id);

        [Get("/{id}")]
        Task<TDto> Buscar([AliasAs("id")] int id);

        [Post("/filtros")]
        Task<DataTableModel<TDto>> Filtrar([Body] DataTableModel<TDto> dataTableModel);
    }
}
