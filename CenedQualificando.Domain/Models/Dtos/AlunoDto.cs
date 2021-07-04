using System;
using System.ComponentModel.DataAnnotations;
using CenedQualificando.Domain.Extensions;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Dtos.Validations;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Enumerations;
using CenedQualificando.Domain.Resources;

namespace CenedQualificando.Domain.Models.Dtos
{
    public class AlunoDto : Dto<Aluno>
    {
        public override int Id => IdAluno;

        public int IdAluno { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationMessageResource),
            ErrorMessageResourceName = nameof(ValidationMessageResource.CampoObrigatorio))]
        public string Nome { get; set; }

        public SexoEnum Sexo { get; set; }

        public string SexoDescricao => Sexo.EnumDescription();

        [CpfValidation]
        [Required(ErrorMessageResourceType = typeof(ValidationMessageResource),
            ErrorMessageResourceName = nameof(ValidationMessageResource.CampoObrigatorio))]
        public string Cpf { get; set; }

        public string Rg { get; set; }

        public string OrgaoExpedidor { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationMessageResource),
            ErrorMessageResourceName = nameof(ValidationMessageResource.CampoObrigatorio))]
        public DateTime? DataNascimento { get; set; }

        public string Naturalidade { get; set; }
        public UfEnum UfNaturalidade { get; set; }
        public string UfNaturalidadeDescricao => UfNaturalidade.EnumDescription();
        public string Nacionalidade { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public UfEnum UfResidencial { get; set; }
        public string UfResidencialDescricao => UfResidencial.EnumDescription();
        public string Cep { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
        public string Celular { get; set; }
        public string FoneResidencial { get; set; }
        public string FoneComercial { get; set; }
        public string Email { get; set; }
        public string NomePreposto { get; set; }
        public VinculoEnum Vinculo { get; set; }
        public string VinculoDescricao => Vinculo.EnumDescription();
        public SexoEnum SexoPreposto { get; set; }
        public string SexoPrepostoDescricao => SexoPreposto.EnumDescription();
        public string CpfPreposto { get; set; }
        public string RgPreposto { get; set; }
        public string OrgaoExpedidorPreposto { get; set; }
        public string GrauInstrucao { get; set; }
        public string AtuacaoHabilitacao { get; set; }
        public string Profissao { get; set; }
        public string LocalTrabalho { get; set; }
        public string CidadeTrabalho { get; set; }
        public UfEnum UfTrabalho { get; set; }
        public string UfTrabalhoDescricao => UfTrabalho.EnumDescription();
        public int IdPenitenciaria { get; set; }
        public string Bloco { get; set; }
        public string Ala { get; set; }
        public string Cela { get; set; }
        public CondicaoPresoEnum CondicaoPreso { get; set; }
        public string CondicaoPresoDescricao => CondicaoPreso.EnumDescription();
        public RegimeEnum Regime { get; set; }
        public string RegimeDescricao => Regime.EnumDescription();
        public string Observacoes { get; set; }

        public PenitenciariaDto Penitenciaria { get; set; } = new PenitenciariaDto();
    }
}
