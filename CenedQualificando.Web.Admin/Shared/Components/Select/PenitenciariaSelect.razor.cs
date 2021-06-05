using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Utils;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Shared.Components.Select
{
    public partial class PenitenciariaSelect
    {
        [Parameter]
        public int Id
        {
            get => Value;
            set
            {
                Value = value;
            }
        }

        [Parameter] public EventCallback<int> IdChanged { get; set; }

        [Parameter] public EventCallback<PenitenciariaDto> OnSelected { get; set; }

        private IEnumerable<SelectResult> Items { get; set; }

        private string ToStringFunc(int id) => Items.FirstOrDefault(x => x.Id == id)?.Text;

        private async Task<IEnumerable<int>> Search(string pesquisa)
        {
            Items = await Service.Penitenciarias(new SelectSearchParam(pesquisa, 20));
            return Items.Select(x => x.Id);
        }

        private int Value { get; set; }

        private void OnValueChanged(int id)
        {
            IdChanged.InvokeAsync(id);
            GetSelectedAsync(id);
        }

        private async Task GetSelectedAsync(int id)
        {
            var result = await PenitenciariaApiService.Buscar(id);
            await OnSelected.InvokeAsync(result);
        }
    }
}
