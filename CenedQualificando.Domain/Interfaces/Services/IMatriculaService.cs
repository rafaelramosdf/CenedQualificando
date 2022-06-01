using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Interfaces.Services
{
    public interface IMatriculaService : IBaseService<Matricula, MatriculaViewModel, MatriculaFilter>
    {
        IEnumerable<MatriculaViewModel> Filtrar(MatriculaFilter filtro);
    }
}
