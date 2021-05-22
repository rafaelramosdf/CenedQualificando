using AutoMapper;
using CenedQualificando.Api.Services.Base;
using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Interfaces.UoW;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Objects;
using Microsoft.EntityFrameworkCore;

namespace CenedQualificando.Api.Services
{
    public class MatriculaService
        : BaseService<Matricula, MatriculaDto, IMatriculaQuery, IMatriculaRepository>, IMatriculaService
    {
        public MatriculaService(
            IMatriculaQuery query,
            IMatriculaRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper) :
            base(query, repository, unitOfWork, mapper)
        {
        }

        public override DataTableModel<MatriculaDto> Buscar(DataTableModel<MatriculaDto> dataTableModel)
        {
            var query = Repository.List().Include(x => x.Aluno).Include(x => x.Curso);

            dataTableModel = GerarDataTable(dataTableModel, query);
            return dataTableModel;
        }
    }
}
