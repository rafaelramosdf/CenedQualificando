using CenedQualificando.Domain.Extensions;
using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Enumerations;
using CenedQualificando.Domain.Models.Filters;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class PenitenciariaQuery : IPenitenciariaQuery
    {
        public Expression<Func<Penitenciaria, bool>> Filtrar(PenitenciariaFilter filtro)
        {
            var ufs = Enum.GetNames(typeof(UfEnum)).Select(s => s.ToUpper()).ToList();
            var filtroUf = ufs.Contains(filtro.Search.ToUpper()) ? filtro.Search.DescriptionTo<UfEnum>() : UfEnum.Null;

            return filtroUf != UfEnum.Null  
                ? x => x.Uf == (int)filtroUf
                : x => x.Nome.Contains(filtro.Search) || x.Cidade.Contains(filtro.Search);
        }

        public Expression<Func<Penitenciaria, object>> Ordenar(string campo)
        {
            switch (campo)
            {
                case nameof(Penitenciaria.Uf):
                    return x => x.Uf;
                case nameof(Penitenciaria.Cidade):
                    return x => x.Cidade;
                default:
                    return x => x.Nome;
            }
        }
    }
}
