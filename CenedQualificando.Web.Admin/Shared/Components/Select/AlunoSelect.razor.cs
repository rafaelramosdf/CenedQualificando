using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Domain.Models.Utils;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Shared.Components.Select
{
    public partial class AlunoSelect
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

        [Parameter] public EventCallback<AlunoDto> OnSelected { get; set; }

        private IEnumerable<SelectResult> Items { get; set; }

        private string ToStringFunc(int id) => Items.FirstOrDefault(x => x.Id == id)?.Text;

        private async Task<IEnumerable<int>> Search(string pesquisa)
        {
            Items = await Service.Alunos(new SelectSearchParam(pesquisa, 20));
            return Items.Select(x => x.Id);
        }

        private int Value { get; set; }

        private async Task OnValueChanged(int id)
        {
            await IdChanged.InvokeAsync(id);
            await GetSelectedAsync(id);
        }

        private async Task GetSelectedAsync(int id)
        {
            var result = await AlunoApiService.Buscar(id);
            await OnSelected.InvokeAsync(result);
        }
    }
}
