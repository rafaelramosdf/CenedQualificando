using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Entities;

namespace Cened.Penitenciario.Api.AutoMapper
{
    [ExcludeFromCodeCoverage]
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AgentePenitenciario, AgentePenitenciarioViewModel>().ReverseMap();
            CreateMap<Aluno, AlunoViewModel>().ReverseMap();
            CreateMap<CargaHorariaDiaria, CargaHorariaDiariaViewModel>().ReverseMap();
            CreateMap<Curso, CursoViewModel>().ReverseMap();
            CreateMap<FiscalSala, FiscalSalaViewModel>().ReverseMap();
            CreateMap<GrupoDePermissao, GrupoDePermissaoViewModel>().ReverseMap();
            CreateMap<ImpressaoCertificado, ImpressaoCertificadoViewModel>().ReverseMap();
            CreateMap<Matricula, MatriculaViewModel>().ReverseMap();
            CreateMap<Penitenciaria, PenitenciariaViewModel>().ReverseMap();
            CreateMap<Permissao, PermissaoViewModel>().ReverseMap();
            CreateMap<Prova, ProvaViewModel>().ReverseMap();
            CreateMap<Representante, RepresentanteViewModel>().ReverseMap();
            CreateMap<UfEntrega, UfEntregaViewModel>().ReverseMap();
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
        }
    }
}
