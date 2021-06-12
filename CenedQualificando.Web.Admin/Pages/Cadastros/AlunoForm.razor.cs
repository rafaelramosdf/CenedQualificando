using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class AlunoForm : FormPageBase
    {
        private AlunoDto Model { get; set; } = new AlunoDto();

        protected override void OnInit()
        {
            State.TituloPagina = "Alunos / Novo";
        }
    }
}
