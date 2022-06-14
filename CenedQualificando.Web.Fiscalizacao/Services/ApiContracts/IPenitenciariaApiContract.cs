using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Filters;
using Refit;
using System.Threading.Tasks;
using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Web.Fiscalizacao.Services.ApiContracts
{
    public interface IPenitenciariaApiContract 
    {
        [Get("/{id}")]
        Task<PenitenciariaViewModel> Buscar([AliasAs("id")] int id);

        [Get("")]
        Task<DataTableModel<PenitenciariaViewModel>> Buscar([Query] PenitenciariaFilter filtro);
    }
}
