using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Web.Admin.Services.RefitApiServices;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class CursoForm : FormPageBase<Curso, CursoDto, ICursoApiService>
    {
        protected override void OnInit()
        {
            State.TituloPagina = "Cursos CENED / Novo";
            BackRoute = "/cadastros/cursos";
        }
    }
}