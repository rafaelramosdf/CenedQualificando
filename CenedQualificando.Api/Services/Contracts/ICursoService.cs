using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Api.Services.Contracts
{
    public interface ICursoService : IBaseService<Curso, CursoDto>
    {
    }
}
