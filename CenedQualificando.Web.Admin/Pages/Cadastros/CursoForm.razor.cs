using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Web.Admin.Services.ApiContracts;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using CenedQualificando.Domain.Models.Filters;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class CursoForm : FormPageBase<Curso, CursoFilter, CursoViewModel, ICursoApiContract>
    {
        protected override void OnInit()
        {
            State.TituloPagina = "Cursos CENED / Novo";
            BackRoute = "/cadastros/cursos";
        }
    }
}