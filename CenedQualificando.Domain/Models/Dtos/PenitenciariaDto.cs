using System;
using CenedQualificando.Domain.Extensions;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Enumerations;

namespace CenedQualificando.Domain.Models.Dtos
{
    public partial class PenitenciariaDto : Dto<Penitenciaria>
    {
        public override int Id => IdPenitenciaria;

        public int IdPenitenciaria { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public UfEnum Uf { get; set; }
        public string UfDescricao => Uf.EnumDescription();
        public string Cep { get; set; }
        public string NomeDepartamentoEnsino { get; set; }
        public string ResponsavelDepartamentoEnsino { get; set; }
        public string TituloCargoDepartamentoEnsino { get; set; }
        public string EmailContatoDepartamentoEnsino { get; set; }
        public AtivoEnum Ativo { get; set; }
        public string AtivoDescricao => Ativo.EnumDescription();
        public bool PossuiBolsaParceria { get; set; }
        public DateTime? DataInicioBolsaParceria { get; set; }
        public int BolsasConcedidas { get; set; }
    }
}
