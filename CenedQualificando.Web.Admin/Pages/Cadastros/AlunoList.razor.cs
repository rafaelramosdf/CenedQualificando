using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Web.Admin.Services.RefitApiServices;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class AlunoList : ListPageBase<Aluno, AlunoDto, IAlunoApiService>
    {
        protected override void OnInit()
        {
            State.TituloPagina = "Alunos / Lista";
            SomenteLeitura = true;
        }
    }
}
