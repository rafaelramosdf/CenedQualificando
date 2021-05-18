using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using AutoMapper;
using CenedQualificando.Api.Models;
using CenedQualificando.Domain.Models;

namespace Cened.Penitenciario.Api.Settings.AutoMapper
{
    [ExcludeFromCodeCoverage]
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<FiscalSala, FiscalSalaModel>().ReverseMap();
            CreateMap<Expression<Func<FiscalSalaModel, bool>>, Expression<Func<FiscalSala, bool>>>().ReverseMap();
            CreateMap<Expression<Func<FiscalSalaModel, object>>, Expression<Func<FiscalSala, object>>>().ReverseMap();
        }
    }
}
