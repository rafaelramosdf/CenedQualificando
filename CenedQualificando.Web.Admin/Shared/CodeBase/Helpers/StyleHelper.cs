using CenedQualificando.Domain.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Shared.CodeBase.Helpers
{
    public static class StyleHelper
    {
        public static MudBlazor.Color ClasseCssStatusCurso(StatusCursoEnum status)
        {
            switch (status)
            {
                case StatusCursoEnum.EmAndamento:
                    return MudBlazor.Color.Success;
                case StatusCursoEnum.Aprovado:
                    return MudBlazor.Color.Primary;
                case StatusCursoEnum.NaoAprovado:
                    return MudBlazor.Color.Warning;
                case StatusCursoEnum.Agendado:
                    return MudBlazor.Color.Info;
                case StatusCursoEnum.ReProva:
                    return MudBlazor.Color.Error;
                default:
                    return MudBlazor.Color.Dark;
            }
        }
    }
}
