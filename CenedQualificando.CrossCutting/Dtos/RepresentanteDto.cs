﻿using CenedQualificando.Domain.Extensions;
using CenedQualificando.CrossCutting.Dtos.Base;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Enumerations;

namespace CenedQualificando.CrossCutting.Dtos
{
    public partial class RepresentanteDto : Dto<Representante>
    {
        public override int Id => IdRepresentante;

        public int IdRepresentante { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public UfEnum Uf { get; set; }
        public string UfDescricao => Uf.EnumDescription();
        public AtivoEnum Ativo { get; set; }
        public string AtivoDescricao => Ativo.EnumDescription();
    }
}