using System.ComponentModel;

namespace CenedQualificando.Domain.Models.Enumerations
{
    public enum TipoPermissao
    {
        PermissaoCadastro,
        PermissaoEtiqueta,
        PermissaoRelatorio,
        PermissaoMensagem,
        PermissaoDocumento,
        PermissaoConfiguracoes
    }

    public enum PermissaoCadastro
    {
        [Description("Cadastro / Consultar")]
        ConsultarCadastro,

        [Description("Aluno / Adicionar")]
        AdicionarAluno,

        [Description("Aluno / Editar")]
        EditarAluno,

        [Description("Aluno / Deletar")]
        DeletarAluno,

        [Description("Curso / Adicionar")]
        AdicionarMatricula,

        [Description("Curso / Editar")]
        EditarMatricula,

        [Description("Curso / Deletar")]
        DeletarMatricula,

        [Description("Prova / Adicionar")]
        AdicionarProva,

        [Description("Prova / Editar")]
        EditarProva,

        [Description("Prova / Deletar")]
        DeletarProva,

        [Description("Despesa Extra / Adicionar")]
        AdicionarDespesaExtra,

        [Description("Despesa Extra / Editar")]
        EditarDespesaExtra,

        [Description("Despesa Extra / Deletar")]
        DeletarDespesaExtra,

        [Description("Matrículas do Site / Ativar")]
        AtivarMatriculaSite,

        [Description("Liquidar Pagamentos / Baixa Automática")]
        LiquidarPagamentos,

        [Description("Liquidar Pagamentos / Baixa Manual")]
        LiquidarPagamentosManualmente,

        [Description("Tabela Cursos Autorizados / Consultar")]
        TabelaCursosAutorizadosConsultar,

        [Description("Tabela Cursos Autorizados / Editar")]
        TabelaCursosAutorizadosEditar,

        [Description("Estoque Material / Consultar")]
        EstoqueMaterialConsultar,

        [Description("Estoque Material / Editar")]
        EstoqueMaterialEditar
    }

    // Permissões ETIQUETAS
    public enum PermissaoEtiqueta
    {
        [Description("Acessar")]
        AcessarEtiqueta,

        [Description("Visualizar")]
        VisualizarEtiqueta,

        [Description("Imprimir")]
        ImprimirEtiqueta
    }

    // Permissões RELATÓRIOS
    public enum PermissaoRelatorio
    {
        [Description("Relatório Sintético")]
        RelatorioSintetico,

        [Description("Relatório Analítico")]
        RelatorioAnalitico,

        [Description("Relatório Financeiro")]
        RelatorioFinanceiro,

        [Description("Relatório Ranking de Vendas")]
        RelatorioRankingVendas,

        [Description("Relatório de Auditoria")]
        RelatorioLogAuditoria
    }

    // Permissões MENSAGEM
    public enum PermissaoMensagem
    {
        [Description("Acessar")]
        AcessarMensagem,

        [Description("Enviar")]
        EnviarMensagem,

        [Description("Visualizar")]
        VisualizarMensagem,

        [Description("Deletar")]
        DeletarMensagem
    }

    // Permissões DOCUMENTOS
    public enum PermissaoDocumento
    {
        [Description("Ata de Provas")]
        AtaDeProvas,

        [Description("Encaminhamento de Certificado")]
        EncaminhamentoDeCertificado,

        [Description("Encaminhamento de Material")]
        EncaminhamentoDeMaterial,

        [Description("Ficha de Matricula")]
        FichaDeMatricula,

        [Description("Livro Digital de Certificados")]
        LivroDigitalDeCertificados,

        [Description("Ofício DF")]
        OficioDf,

        [Description("Ofício Outras UFs")]
        OficioUfs,

        [Description("Resultado de Provas")]
        ResultadoDeProvas,

        [Description("Declaração")]
        DeclaracaoDeMatricula
    }

    // Permissões CONFIGURAÇÕES
    public enum PermissaoConfiguracoes
    {
        [Description("Autorizar Curso por UF")]
        AutorizarCursoPorUf,

        [Description("CH Diária Padrão")]
        ChDiariaPadrao,

        [Description("Cursos CENED")]
        CursosCened,

        [Description("Fiscal de Sala")]
        FiscalDeSala,

        [Description("Mensagem Personalizada")]
        MensagemPersonalizada,

        [Description("Penitenciarias")]
        Penitenciarias,

        [Description("Representantes")]
        Representantes,

        [Description("Taxa de Entrega/Frete")]
        TaxaDeEntregaFrete,

        [Description("Grupo de Permissões")]
        GrupoDePermissoes,

        [Description("Usuários do Sistema")]
        UsuariosDoSistema,

        [Description("Grupos de Prova")]
        GruposDeProva,

        [Description("Administrador Financeiro (Gera Token e Pagamento Manual)")]
        AdministradorFinanceiro,

        [Description("Permitir Acesso fora de expediente")]
        AcessoForaDeExpediente,

        [Description("Cadastro de Agentes Penitenciários")]
        UsuariosAgentePenitenciario,

        [Description("Permitir Aplicar Bolsa Parceria Integral")]
        AplicarBolsaParceria
    }
}