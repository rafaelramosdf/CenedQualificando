using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Web.Admin.Services.RefitApiServices;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class MatriculaForm : FormPageBase<Matricula, MatriculaDto, IMatriculaApiService>
    {
        protected override void OnInit()
        {
            State.TituloPagina = "Matrículas / Novo";
            BackRoute = "/cadastros/matriculas";
        }
    }
}
