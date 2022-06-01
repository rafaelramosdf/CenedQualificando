using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Queries.Filters.Base;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.RefitApiServices.Base
{
    public interface ICRUDService<TEntity, TFilter, TViewModel>
        where TEntity : Entity
        where TFilter : Filter
        where TViewModel : ViewModel<TEntity>
    {
        [Post("")]
        Task<CommandResult> Incluir([Body] TViewModel model);

        [Put("/{id}")]
        Task<CommandResult> Alterar([AliasAs("id")] int id, [Body] TViewModel model);

        [Delete("/{id}")]
        Task<CommandResult> Excluir([AliasAs("id")] int id);

        [Get("/{id}")]
        Task<TViewModel> Buscar([AliasAs("id")] int id);

        [Post("")]
        Task<DataTableModel<TViewModel>> Buscar([Body] TFilter filtro);
    }
}
