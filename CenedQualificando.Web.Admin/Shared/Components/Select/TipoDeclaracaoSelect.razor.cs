using CenedQualificando.Domain.Models.Enumerations;
using Microsoft.AspNetCore.Components;

namespace CenedQualificando.Web.Admin.Shared.Components.Select
{
    public partial class TipoDeclaracaoSelect
    {
        [Parameter] public TipoDeclaracaoEnum Value { get; set; }
        [Parameter] public EventCallback<TipoDeclaracaoEnum> ValueChanged { get; set; }

        private void OnValueChanged(TipoDeclaracaoEnum value)
        {
            ValueChanged.InvokeAsync(value);
        }
    }
}
