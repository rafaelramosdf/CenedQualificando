using Microsoft.EntityFrameworkCore.Migrations;

namespace CenedQualificando.Infra.Migrations
{
    public partial class AtualizandoSequencial_20201011_1200 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RestartSequence(
                name: "SequencialUfEntrega",
                startValue: 28L);

            migrationBuilder.RestartSequence(
                name: "SequencialTransacaoCieloSolicitacaoCertificado",
                startValue: 1498L);

            migrationBuilder.RestartSequence(
                name: "SequencialTransacao",
                startValue: 24394L);

            migrationBuilder.RestartSequence(
                name: "SequencialToken",
                startValue: 2817L);

            migrationBuilder.RestartSequence(
                name: "SequencialTabelaHistoricoCurso",
                startValue: 16L);

            migrationBuilder.RestartSequence(
                name: "SequencialTabelaCursosAutorizados",
                startValue: 3119L);

            migrationBuilder.RestartSequence(
                name: "SequencialSolicitacaoCertificado",
                startValue: 2500L);

            migrationBuilder.RestartSequence(
                name: "SequencialSolicitacaoAutorizacaoMatriculaCursos",
                startValue: 469L);

            migrationBuilder.RestartSequence(
                name: "SequencialSolicitacaoAutorizacaoMatricula",
                startValue: 366L);

            migrationBuilder.RestartSequence(
                name: "SequencialRepresentante",
                startValue: 10L);

            migrationBuilder.RestartSequence(
                name: "SequencialProva",
                startValue: 26438L);

            migrationBuilder.RestartSequence(
                name: "SequencialPermissao",
                startValue: 1235L);

            migrationBuilder.RestartSequence(
                name: "SequencialPenitenciaria",
                startValue: 385L);

            migrationBuilder.RestartSequence(
                name: "SequencialNumeroOficio",
                startValue: 1543L);

            migrationBuilder.RestartSequence(
                name: "SequencialNumeroMatricula",
                startValue: 24838L);

            migrationBuilder.RestartSequence(
                name: "SequencialNumeroCertificado",
                startValue: 19906L);

            migrationBuilder.RestartSequence(
                name: "SequencialMensagemPersonalizada",
                startValue: 3L);

            migrationBuilder.RestartSequence(
                name: "SequencialMensagem",
                startValue: 1422L);

            migrationBuilder.RestartSequence(
                name: "SequencialMatricula",
                startValue: 30010L);

            migrationBuilder.RestartSequence(
                name: "SequencialLogAuditoria",
                startValue: 8104L);

            migrationBuilder.RestartSequence(
                name: "SequencialImpressaoCertificado",
                startValue: 121L);

            migrationBuilder.RestartSequence(
                name: "SequencialGruposProvaUf",
                startValue: 7L);

            migrationBuilder.RestartSequence(
                name: "SequencialGrupoProva",
                startValue: 3L);

            migrationBuilder.RestartSequence(
                name: "SequencialGrupoDePermissao",
                startValue: 12L);

            migrationBuilder.RestartSequence(
                name: "SequencialFiscalSala",
                startValue: 17L);

            migrationBuilder.RestartSequence(
                name: "SequencialEstoqueMaterial",
                startValue: 92L);

            migrationBuilder.RestartSequence(
                name: "SequencialDespesaExtra",
                startValue: 866L);

            migrationBuilder.RestartSequence(
                name: "SequencialDeclaracaoCursosConcluidos",
                startValue: 222L);

            migrationBuilder.RestartSequence(
                name: "SequencialCursoUf",
                startValue: 343L);

            migrationBuilder.RestartSequence(
                name: "SequencialCurso",
                startValue: 138L);

            migrationBuilder.RestartSequence(
                name: "SequencialCargaHorariaDiaria",
                startValue: 32L);

            migrationBuilder.RestartSequence(
                name: "SequencialAluno",
                startValue: 9482L);

            migrationBuilder.RestartSequence(
                name: "SequencialAgentePenitenciarioParceriaPagamentos",
                startValue: 1L);

            migrationBuilder.RestartSequence(
                name: "SequencialAgentePenitenciarioParceria",
                startValue: 16L);

            migrationBuilder.RestartSequence(
                name: "SequencialAgentePenitenciario",
                startValue: 35L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RestartSequence(
                name: "SequencialUfEntrega",
                startValue: 27L);

            migrationBuilder.RestartSequence(
                name: "SequencialTransacaoCieloSolicitacaoCertificado",
                startValue: 790L);

            migrationBuilder.RestartSequence(
                name: "SequencialTransacao",
                startValue: 16977L);

            migrationBuilder.RestartSequence(
                name: "SequencialToken",
                startValue: 2816L);

            migrationBuilder.RestartSequence(
                name: "SequencialTabelaHistoricoCurso",
                startValue: 15L);

            migrationBuilder.RestartSequence(
                name: "SequencialTabelaCursosAutorizados",
                startValue: 3054L);

            migrationBuilder.RestartSequence(
                name: "SequencialSolicitacaoCertificado",
                startValue: 1187L);

            migrationBuilder.RestartSequence(
                name: "SequencialSolicitacaoAutorizacaoMatriculaCursos",
                startValue: 458L);

            migrationBuilder.RestartSequence(
                name: "SequencialSolicitacaoAutorizacaoMatricula",
                startValue: 355L);

            migrationBuilder.RestartSequence(
                name: "SequencialRepresentante",
                startValue: 8L);

            migrationBuilder.RestartSequence(
                name: "SequencialProva",
                startValue: 20825L);

            migrationBuilder.RestartSequence(
                name: "SequencialPermissao",
                startValue: 1234L);

            migrationBuilder.RestartSequence(
                name: "SequencialPenitenciaria",
                startValue: 317L);

            migrationBuilder.RestartSequence(
                name: "SequencialNumeroOficio",
                startValue: 1464L);

            migrationBuilder.RestartSequence(
                name: "SequencialNumeroMatricula",
                startValue: 19078L);

            migrationBuilder.RestartSequence(
                name: "SequencialNumeroCertificado",
                startValue: 15387L);

            migrationBuilder.RestartSequence(
                name: "SequencialMensagemPersonalizada",
                startValue: 2L);

            migrationBuilder.RestartSequence(
                name: "SequencialMensagem",
                startValue: 1421L);

            migrationBuilder.RestartSequence(
                name: "SequencialMatricula",
                startValue: 23015L);

            migrationBuilder.RestartSequence(
                name: "SequencialLogAuditoria",
                startValue: 8103L);

            migrationBuilder.RestartSequence(
                name: "SequencialImpressaoCertificado",
                startValue: 99L);

            migrationBuilder.RestartSequence(
                name: "SequencialGruposProvaUf",
                startValue: 6L);

            migrationBuilder.RestartSequence(
                name: "SequencialGrupoProva",
                startValue: 2L);

            migrationBuilder.RestartSequence(
                name: "SequencialGrupoDePermissao",
                startValue: 11L);

            migrationBuilder.RestartSequence(
                name: "SequencialFiscalSala",
                startValue: 15L);

            migrationBuilder.RestartSequence(
                name: "SequencialEstoqueMaterial",
                startValue: 76L);

            migrationBuilder.RestartSequence(
                name: "SequencialDespesaExtra",
                startValue: 755L);

            migrationBuilder.RestartSequence(
                name: "SequencialDeclaracaoCursosConcluidos",
                startValue: 104L);

            migrationBuilder.RestartSequence(
                name: "SequencialCursoUf",
                startValue: 172L);

            migrationBuilder.RestartSequence(
                name: "SequencialCurso",
                startValue: 116L);

            migrationBuilder.RestartSequence(
                name: "SequencialCargaHorariaDiaria",
                startValue: 31L);

            migrationBuilder.RestartSequence(
                name: "SequencialAluno",
                startValue: 7547L);

            migrationBuilder.RestartSequence(
                name: "SequencialAgentePenitenciarioParceriaPagamentos",
                startValue: 100L);

            migrationBuilder.RestartSequence(
                name: "SequencialAgentePenitenciarioParceria",
                startValue: 100L);

            migrationBuilder.RestartSequence(
                name: "SequencialAgentePenitenciario",
                startValue: 100L);
        }
    }
}
