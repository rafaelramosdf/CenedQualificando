﻿using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Domain.Models;
using CenedQualificando.Infra.Context;
using CenedQualificando.Infra.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Infra.Repository
{
    public class ProvaRepository : BaseRepository<Prova>, IProvaRepository
    {
        public ProvaRepository(EntityContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Prova>> BuscarProvasPorIdMatriculas(int[] idMatriculas)
        {
            return null;
            // TODO: Refazer com EntityFramework
            //return await GetAllAsync($@"WHERE Prova.IdMatricula IN ({string.Join(",", idMatriculas)})");
        }
    }
}
