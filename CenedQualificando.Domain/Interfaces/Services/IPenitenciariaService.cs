﻿using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Models.ValueObjects;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Interfaces.Services
{
    public interface IPenitenciariaService : IBaseService<Penitenciaria, PenitenciariaDto, PenitenciariaFilter>
    {
        IEnumerable<SelectResult> ObterComboSelecao(string pesquisa, int quantidade = 10, int selecionado = 0);
    }
}
