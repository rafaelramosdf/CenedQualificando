﻿using System;
using CenedQualificando.Domain.Extensions;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.ViewModels.Validations;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Enumerations;

namespace CenedQualificando.Domain.Models.ViewModels
{
    public class AlunoViewModel : ViewModel<Aluno>
    {
        public override int Id => IdAluno;

        public int IdAluno { get; set; }

        [RequiredValidation("Nome do Cursista")]
        public string Nome { get; set; }

        public SexoEnum Sexo { get; set; }

        public string SexoDescricao => Sexo.EnumDescription();

        [RequiredValidation("CPF do Cursista"), CpfValidation]
        public string Cpf { get; set; }

        public string Rg { get; set; }

        public string OrgaoExpedidor { get; set; }

        [RequiredValidation("Data de Nascimento")]
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

        [RequiredValidation("Nome do Preposto")]
        public string NomePreposto { get; set; }

        public VinculoEnum Vinculo { get; set; }
        public string VinculoDescricao => Vinculo.EnumDescription();
        public SexoEnum SexoPreposto { get; set; }
        public string SexoPrepostoDescricao => SexoPreposto.EnumDescription();

        [RequiredValidation("CPF do Preposto")]
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

        [RequiredValidation("Penitenciária")]
        public int IdPenitenciaria { get; set; }

        public string Bloco { get; set; }
        public string Ala { get; set; }
        public string Cela { get; set; }
        public CondicaoPresoEnum CondicaoPreso { get; set; }
        public string CondicaoPresoDescricao => CondicaoPreso.EnumDescription();
        public RegimeEnum Regime { get; set; }
        public string RegimeDescricao => Regime.EnumDescription();
        public string Observacoes { get; set; }

        public PenitenciariaViewModel Penitenciaria { get; set; } = new PenitenciariaViewModel();
    }
}
