using Microsoft.EntityFrameworkCore.Migrations;

namespace CenedQualificando.Infra.Migrations
{
    public partial class IniciandoSequencial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Penitenciario");

            migrationBuilder.CreateSequence<int>(
                name: "SequencialAgentePenitenciario",
                startValue: 100L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialAgentePenitenciarioParceria",
                startValue: 100L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialAgentePenitenciarioParceriaPagamentos",
                startValue: 100L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialAluno",
                startValue: 7547L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialCargaHorariaDiaria",
                startValue: 31L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialCurso",
                startValue: 116L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialCursoUf",
                startValue: 172L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialDeclaracaoCursosConcluidos",
                startValue: 104L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialDespesaExtra",
                startValue: 755L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialEstoqueMaterial",
                startValue: 76L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialFiscalSala",
                startValue: 15L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialGrupoDePermissao",
                startValue: 11L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialGrupoProva",
                startValue: 2L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialGruposProvaUf",
                startValue: 6L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialHistoricoCurso",
                startValue: 379998L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialImpressaoCertificado",
                startValue: 99L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialLogAuditoria",
                startValue: 8103L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialMatricula",
                startValue: 23015L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialMensagem",
                startValue: 1421L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialMensagemPersonalizada",
                startValue: 2L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialNumeroCertificado",
                startValue: 15387L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialNumeroMatricula",
                startValue: 19078L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialNumeroOficio",
                startValue: 1464L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialPenitenciaria",
                startValue: 317L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialPermissao",
                startValue: 1234L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialProva",
                startValue: 20825L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialRepresentante",
                startValue: 8L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialSolicitacaoAutorizacaoMatricula",
                startValue: 355L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialSolicitacaoAutorizacaoMatriculaCursos",
                startValue: 458L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialSolicitacaoCertificado",
                startValue: 1187L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialTabelaCursosAutorizados",
                startValue: 3054L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialTabelaHistoricoCurso",
                startValue: 15L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialToken",
                startValue: 2816L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialTransacao",
                startValue: 16977L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialTransacaoCieloSolicitacaoCertificado",
                startValue: 790L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialUfEntrega",
                startValue: 27L);

            migrationBuilder.CreateSequence<int>(
                name: "SequencialUsuario",
                startValue: 33L);



            migrationBuilder.AlterColumn<int>(
                name: "IdUf",
                schema: "Penitenciario",
                table: "UfEntrega",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialUfEntrega",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdTransacaoCieloSolicitacaoCertificado",
                schema: "Penitenciario",
                table: "TransacaoCieloSolicitacaoCertificado",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialTransacaoCieloSolicitacaoCertificado",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdTransacao",
                schema: "Penitenciario",
                table: "Transacao",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialTransacao",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdToken",
                schema: "Penitenciario",
                table: "Token",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialToken",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdTabelaHistoricoCurso",
                schema: "Penitenciario",
                table: "TabelaHistoricoCurso",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialTabelaHistoricoCurso",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdTabelaCursosAutorizados",
                schema: "Penitenciario",
                table: "TabelaCursosAutorizados",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialTabelaCursosAutorizados",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdSolicitacaoCertificado",
                schema: "Penitenciario",
                table: "SolicitacaoCertificado",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialSolicitacaoCertificado",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdSolicitacaoAutorizacaoMatriculaCursos",
                schema: "Penitenciario",
                table: "SolicitacaoAutorizacaoMatriculaCursos",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialSolicitacaoAutorizacaoMatriculaCursos",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdSolicitacaoAutorizacaoMatricula",
                schema: "Penitenciario",
                table: "SolicitacaoAutorizacaoMatricula",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialSolicitacaoAutorizacaoMatricula",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdRepresentante",
                schema: "Penitenciario",
                table: "Representante",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialRepresentante",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdProva",
                schema: "Penitenciario",
                table: "Prova",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialProva",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdPermissao",
                schema: "Penitenciario",
                table: "Permissao",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialPermissao",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdPenitenciaria",
                schema: "Penitenciario",
                table: "Penitenciaria",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialPenitenciaria",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdNumeroOficio",
                schema: "Penitenciario",
                table: "NumeroOficio",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialNumeroOficio",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdNumeroMatricula",
                schema: "Penitenciario",
                table: "NumeroMatricula",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialNumeroMatricula",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdNumeroCertificado",
                schema: "Penitenciario",
                table: "NumeroCertificado",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialNumeroCertificado",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdMensagemPersonalizada",
                schema: "Penitenciario",
                table: "MensagemPersonalizada",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialMensagemPersonalizada",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdMensagem",
                schema: "Penitenciario",
                table: "Mensagem",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialMensagem",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdMatricula",
                schema: "Penitenciario",
                table: "Matricula",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialMatricula",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdLogAuditoria",
                schema: "Penitenciario",
                table: "LogAuditoria",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialLogAuditoria",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdImpressaoCertificado",
                schema: "Penitenciario",
                table: "ImpressaoCertificado",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialImpressaoCertificado",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdHistoricoCurso",
                schema: "Penitenciario",
                table: "HistoricoCurso",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialHistoricoCurso",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdGruposProvaUf",
                schema: "Penitenciario",
                table: "GruposProvaUf",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialGruposProvaUf",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdGrupoProva",
                schema: "Penitenciario",
                table: "GrupoProva",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialGrupoProva",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdGrupoDePermissao",
                schema: "Penitenciario",
                table: "GrupoDePermissao",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialGrupoDePermissao",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdEstoqueMaterial",
                schema: "Penitenciario",
                table: "EstoqueMaterial",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialEstoqueMaterial",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdDespesaExtra",
                schema: "Penitenciario",
                table: "DespesaExtra",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialDespesaExtra",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdDeclaracaoCursosConcluidos",
                schema: "Penitenciario",
                table: "DeclaracaoCursosConcluidos",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialDeclaracaoCursosConcluidos",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdCursoUf",
                schema: "Penitenciario",
                table: "CursoUf",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialCursoUf",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdCurso",
                schema: "Penitenciario",
                table: "Curso",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialCurso",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdCargaHorariaDiaria",
                schema: "Penitenciario",
                table: "CargaHorariaDiaria",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialCargaHorariaDiaria",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdAluno",
                schema: "Penitenciario",
                table: "Aluno",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialAluno",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdAgentePenitenciarioParceriaPagamentos",
                schema: "Penitenciario",
                table: "AgentePenitenciarioParceriaPagamentos",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialAgentePenitenciarioParceriaPagamentos",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdAgentePenitenciarioParceria",
                schema: "Penitenciario",
                table: "AgentePenitenciarioParceria",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialAgentePenitenciarioParceria",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdAgentePenitenciario",
                schema: "Penitenciario",
                table: "AgentePenitenciario",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialAgentePenitenciario",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdUsuario",
                schema: "Penitenciario",
                table: "Usuario",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR SequencialUsuario",
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "SequencialAgentePenitenciario");

            migrationBuilder.DropSequence(
                name: "SequencialAgentePenitenciarioParceria");

            migrationBuilder.DropSequence(
                name: "SequencialAgentePenitenciarioParceriaPagamentos");

            migrationBuilder.DropSequence(
                name: "SequencialAluno");

            migrationBuilder.DropSequence(
                name: "SequencialCargaHorariaDiaria");

            migrationBuilder.DropSequence(
                name: "SequencialCurso");

            migrationBuilder.DropSequence(
                name: "SequencialCursoUf");

            migrationBuilder.DropSequence(
                name: "SequencialDeclaracaoCursosConcluidos");

            migrationBuilder.DropSequence(
                name: "SequencialDespesaExtra");

            migrationBuilder.DropSequence(
                name: "SequencialEstoqueMaterial");

            migrationBuilder.DropSequence(
                name: "SequencialGrupoDePermissao");

            migrationBuilder.DropSequence(
                name: "SequencialGrupoProva");

            migrationBuilder.DropSequence(
                name: "SequencialGruposProvaUf");

            migrationBuilder.DropSequence(
                name: "SequencialHistoricoCurso");

            migrationBuilder.DropSequence(
                name: "SequencialImpressaoCertificado");

            migrationBuilder.DropSequence(
                name: "SequencialLogAuditoria");

            migrationBuilder.DropSequence(
                name: "SequencialMatricula");

            migrationBuilder.DropSequence(
                name: "SequencialMensagem");

            migrationBuilder.DropSequence(
                name: "SequencialMensagemPersonalizada");

            migrationBuilder.DropSequence(
                name: "SequencialNumeroCertificado");

            migrationBuilder.DropSequence(
                name: "SequencialNumeroMatricula");

            migrationBuilder.DropSequence(
                name: "SequencialNumeroOficio");

            migrationBuilder.DropSequence(
                name: "SequencialPenitenciaria");

            migrationBuilder.DropSequence(
                name: "SequencialPermissao");

            migrationBuilder.DropSequence(
                name: "SequencialProva");

            migrationBuilder.DropSequence(
                name: "SequencialRepresentante");

            migrationBuilder.DropSequence(
                name: "SequencialSolicitacaoAutorizacaoMatricula");

            migrationBuilder.DropSequence(
                name: "SequencialSolicitacaoAutorizacaoMatriculaCursos");

            migrationBuilder.DropSequence(
                name: "SequencialSolicitacaoCertificado");

            migrationBuilder.DropSequence(
                name: "SequencialTabelaCursosAutorizados");

            migrationBuilder.DropSequence(
                name: "SequencialTabelaHistoricoCurso");

            migrationBuilder.DropSequence(
                name: "SequencialToken");

            migrationBuilder.DropSequence(
                name: "SequencialTransacao");

            migrationBuilder.DropSequence(
                name: "SequencialTransacaoCieloSolicitacaoCertificado");

            migrationBuilder.DropSequence(
                name: "SequencialUfEntrega");

            migrationBuilder.DropSequence(
                name: "SequencialUsuario");

            migrationBuilder.AlterColumn<int>(
                name: "IdUf",
                schema: "Penitenciario",
                table: "UfEntrega",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialUfEntrega");

            migrationBuilder.AlterColumn<int>(
                name: "IdTransacaoCieloSolicitacaoCertificado",
                schema: "Penitenciario",
                table: "TransacaoCieloSolicitacaoCertificado",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialTransacaoCieloSolicitacaoCertificado");

            migrationBuilder.AlterColumn<int>(
                name: "IdTransacao",
                schema: "Penitenciario",
                table: "Transacao",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialTransacao");

            migrationBuilder.AlterColumn<int>(
                name: "IdToken",
                schema: "Penitenciario",
                table: "Token",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialToken");

            migrationBuilder.AlterColumn<int>(
                name: "IdTabelaHistoricoCurso",
                schema: "Penitenciario",
                table: "TabelaHistoricoCurso",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialTabelaHistoricoCurso");

            migrationBuilder.AlterColumn<int>(
                name: "IdTabelaCursosAutorizados",
                schema: "Penitenciario",
                table: "TabelaCursosAutorizados",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialTabelaCursosAutorizados");

            migrationBuilder.AlterColumn<int>(
                name: "IdSolicitacaoCertificado",
                schema: "Penitenciario",
                table: "SolicitacaoCertificado",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialSolicitacaoCertificado");

            migrationBuilder.AlterColumn<int>(
                name: "IdSolicitacaoAutorizacaoMatriculaCursos",
                schema: "Penitenciario",
                table: "SolicitacaoAutorizacaoMatriculaCursos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialSolicitacaoAutorizacaoMatriculaCursos");

            migrationBuilder.AlterColumn<int>(
                name: "IdSolicitacaoAutorizacaoMatricula",
                schema: "Penitenciario",
                table: "SolicitacaoAutorizacaoMatricula",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialSolicitacaoAutorizacaoMatricula");

            migrationBuilder.AlterColumn<int>(
                name: "IdRepresentante",
                schema: "Penitenciario",
                table: "Representante",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialRepresentante");

            migrationBuilder.AlterColumn<int>(
                name: "IdProva",
                schema: "Penitenciario",
                table: "Prova",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialProva");

            migrationBuilder.AlterColumn<int>(
                name: "IdPermissao",
                schema: "Penitenciario",
                table: "Permissao",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialPermissao");

            migrationBuilder.AlterColumn<int>(
                name: "IdPenitenciaria",
                schema: "Penitenciario",
                table: "Penitenciaria",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialPenitenciaria");

            migrationBuilder.AlterColumn<int>(
                name: "IdNumeroOficio",
                schema: "Penitenciario",
                table: "NumeroOficio",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialNumeroOficio");

            migrationBuilder.AlterColumn<int>(
                name: "IdNumeroMatricula",
                schema: "Penitenciario",
                table: "NumeroMatricula",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialNumeroMatricula");

            migrationBuilder.AlterColumn<int>(
                name: "IdNumeroCertificado",
                schema: "Penitenciario",
                table: "NumeroCertificado",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialNumeroCertificado");

            migrationBuilder.AlterColumn<int>(
                name: "IdMensagemPersonalizada",
                schema: "Penitenciario",
                table: "MensagemPersonalizada",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialMensagemPersonalizada");

            migrationBuilder.AlterColumn<int>(
                name: "IdMensagem",
                schema: "Penitenciario",
                table: "Mensagem",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialMensagem");

            migrationBuilder.AlterColumn<int>(
                name: "IdMatricula",
                schema: "Penitenciario",
                table: "Matricula",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialMatricula");

            migrationBuilder.AlterColumn<int>(
                name: "IdLogAuditoria",
                schema: "Penitenciario",
                table: "LogAuditoria",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialLogAuditoria");

            migrationBuilder.AlterColumn<int>(
                name: "IdImpressaoCertificado",
                schema: "Penitenciario",
                table: "ImpressaoCertificado",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialImpressaoCertificado");

            migrationBuilder.AlterColumn<int>(
                name: "IdHistoricoCurso",
                schema: "Penitenciario",
                table: "HistoricoCurso",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialHistoricoCurso");

            migrationBuilder.AlterColumn<int>(
                name: "IdGruposProvaUf",
                schema: "Penitenciario",
                table: "GruposProvaUf",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialGruposProvaUf");

            migrationBuilder.AlterColumn<int>(
                name: "IdGrupoProva",
                schema: "Penitenciario",
                table: "GrupoProva",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialGrupoProva");

            migrationBuilder.AlterColumn<int>(
                name: "IdGrupoDePermissao",
                schema: "Penitenciario",
                table: "GrupoDePermissao",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialGrupoDePermissao");

            migrationBuilder.AlterColumn<int>(
                name: "IdEstoqueMaterial",
                schema: "Penitenciario",
                table: "EstoqueMaterial",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialEstoqueMaterial");

            migrationBuilder.AlterColumn<int>(
                name: "IdDespesaExtra",
                schema: "Penitenciario",
                table: "DespesaExtra",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialDespesaExtra");

            migrationBuilder.AlterColumn<int>(
                name: "IdDeclaracaoCursosConcluidos",
                schema: "Penitenciario",
                table: "DeclaracaoCursosConcluidos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialDeclaracaoCursosConcluidos");

            migrationBuilder.AlterColumn<int>(
                name: "IdCursoUf",
                schema: "Penitenciario",
                table: "CursoUf",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialCursoUf");

            migrationBuilder.AlterColumn<int>(
                name: "IdCurso",
                schema: "Penitenciario",
                table: "Curso",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialCurso");

            migrationBuilder.AlterColumn<int>(
                name: "IdCargaHorariaDiaria",
                schema: "Penitenciario",
                table: "CargaHorariaDiaria",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialCargaHorariaDiaria");

            migrationBuilder.AlterColumn<int>(
                name: "IdAluno",
                schema: "Penitenciario",
                table: "Aluno",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialAluno");

            migrationBuilder.AlterColumn<int>(
                name: "IdAgentePenitenciarioParceriaPagamentos",
                schema: "Penitenciario",
                table: "AgentePenitenciarioParceriaPagamentos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialAgentePenitenciarioParceriaPagamentos");

            migrationBuilder.AlterColumn<int>(
                name: "IdAgentePenitenciarioParceria",
                schema: "Penitenciario",
                table: "AgentePenitenciarioParceria",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialAgentePenitenciarioParceria");

            migrationBuilder.AlterColumn<int>(
                name: "IdAgentePenitenciario",
                schema: "Penitenciario",
                table: "AgentePenitenciario",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialAgentePenitenciario");

            migrationBuilder.AlterColumn<int>(
                name: "IdUsuario",
                schema: "Penitenciario",
                table: "Usuario",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "NEXT VALUE FOR SequencialUsuario");
        }
    }
}
