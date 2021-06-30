using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class MatriculaForm : FormPageBase
    {
        private MatriculaDto Model { get; set; } = new MatriculaDto();

        protected override void OnInit()
        {
            State.TituloPagina = "Matrículas / Novo";
        }
    }
}
