using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Filters;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Fiscalizacao.Services.ApiContracts
{
    public interface IComboEntidadeApiContract
    {
        [Get("/penitenciarias")]
        Task<IEnumerable<SelectResult>> Penitenciarias([Query] SelectSearchParam param);

        [Get("/filtros/penitenciarias")]
        Task<IEnumerable<SelectResult>> Penitenciarias([Query] PenitenciariaFilter param);

        [Get("/alunos")]
        Task<IEnumerable<SelectResult>> Alunos([Query] SelectSearchParam param);

        [Get("/cursos")]
        Task<IEnumerable<SelectResult>> Cursos([Query] SelectSearchParam param);

        [Get("/usuarios")]
        Task<IEnumerable<SelectResult>> Usuarios([Query] SelectSearchParam param);
    }
}
