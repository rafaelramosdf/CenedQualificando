using CenedQualificando.Domain.Models.Enumerations;
using Microsoft.AspNetCore.Components;

namespace CenedQualificando.Web.Admin.Shared.Components.Select
{
    public partial class TipoOficioSelect
    {
        [Parameter] public TipoOficioEnum Value { get; set; }
        [Parameter] public EventCallback<TipoOficioEnum> ValueChanged { get; set; }

        private void OnValueChanged(TipoOficioEnum value)
        {
            ValueChanged.InvokeAsync(value);
        }
    }
}