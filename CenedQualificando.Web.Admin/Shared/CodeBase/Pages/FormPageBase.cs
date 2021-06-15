using Microsoft.AspNetCore.Components;

namespace CenedQualificando.Web.Admin.Shared.CodeBase.Pages
{
    public abstract partial class FormPageBase : PageBase
    {
        [Parameter] public int? Id { get; set; }
    }
}
