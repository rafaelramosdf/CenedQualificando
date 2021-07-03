using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class CursoForm : FormPageBase
    {
        private CursoDto Model { get; set; } = new CursoDto();

        protected override void OnInit()
        {
            State.TituloPagina = "Cursos CENED / Novo";
        }
    }
}