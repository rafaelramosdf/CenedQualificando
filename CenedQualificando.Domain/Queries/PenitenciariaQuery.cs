using CenedQualificando.Domain.Extensions;
using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Enumerations;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Queries
{
    public class PenitenciariaQuery : IPenitenciariaQuery
    {
        public Expression<Func<Penitenciaria, bool>> FiltroGenerico(string textoFiltro)
        {
            var ufs = Enum.GetNames(typeof(UfEnum)).Select(s => s.ToUpper()).ToList();
            var filtroUf = ufs.Contains(textoFiltro.ToUpper()) ? textoFiltro.DescriptionTo<UfEnum>() : UfEnum.Null;

            return filtroUf != UfEnum.Null  
                ? x => x.Uf == (int)filtroUf
                : x => x.Nome.Contains(textoFiltro) || x.Cidade.Contains(textoFiltro);
        }

        public Expression<Func<Penitenciaria, object>> Ordenacao(string campo)
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
