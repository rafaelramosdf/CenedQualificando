using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
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
            CreateMap<FiscalSala, FiscalSalaDto>().ReverseMap();
            CreateMap<Expression<Func<FiscalSalaDto, bool>>, Expression<Func<FiscalSala, bool>>>().ReverseMap();
            CreateMap<Expression<Func<FiscalSalaDto, object>>, Expression<Func<FiscalSala, object>>>().ReverseMap();
        }
    }
}
