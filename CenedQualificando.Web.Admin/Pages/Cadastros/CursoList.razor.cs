using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Web.Admin.Services.RefitApiServices;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using CenedQualificando.Domain.Models.Filters;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class CursoList : ListPageBase<Curso, CursoFilter, CursoViewModel, ICursoApiService>
    {
        protected override void OnInit()
        {
            State.TituloPagina = "Cursos CENED / Lista";
        }
    }
}
