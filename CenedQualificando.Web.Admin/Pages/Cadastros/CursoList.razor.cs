using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Web.Admin.Services.RefitApiServices;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class CursoList : ListPageBase<Curso, CursoDto, ICursoApiService>
    {
        protected override void OnInit()
        {
            State.TituloPagina = "Cursos CENED / Lista";
        }
    }
}
