using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Pages.Documentos
{
    public partial class CertificadoImpressao : DocumentPrintPageBase
    {
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await Task.Delay(1500);
        }
    }
}
