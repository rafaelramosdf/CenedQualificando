using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;

namespace Cened.Penitenciario.Api.AutoMapper
{
    [ExcludeFromCodeCoverage]
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AgentePenitenciario, AgentePenitenciarioDto>().ReverseMap();
            CreateMap<Aluno, AlunoDto>().ReverseMap();
            CreateMap<CargaHorariaDiaria, CargaHorariaDiariaDto>().ReverseMap();
            CreateMap<Curso, CursoDto>().ReverseMap();
            CreateMap<FiscalSala, FiscalSalaDto>().ReverseMap();
            CreateMap<GrupoDePermissao, GrupoDePermissaoDto>().ReverseMap();
            CreateMap<ImpressaoCertificado, ImpressaoCertificadoDto>().ReverseMap();
            CreateMap<Matricula, MatriculaDto>().ReverseMap();
            CreateMap<Penitenciaria, PenitenciariaDto>().ReverseMap();
            CreateMap<Permissao, PermissaoDto>().ReverseMap();
            CreateMap<Prova, ProvaDto>().ReverseMap();
            CreateMap<Representante, RepresentanteDto>().ReverseMap();
            CreateMap<UfEntrega, UfEntregaDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
        }
    }
}
