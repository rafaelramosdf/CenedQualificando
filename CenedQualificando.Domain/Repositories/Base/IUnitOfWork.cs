using System;

namespace CenedQualificando.Domain.Repositories.Base
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();

        /// <summary>
        /// Abre a Transação (obs.: dentros do bloco de transaction deve-se usar o comando "Commit()" e por último o "CommitTransaction"
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Salva a Transação (obs.: Consolida e salva no banco de dados todas as alterações comitadas com o comando "Commit()".
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// Reverte as alterações de uma tranação
        /// </summary>
        void Rollback();
    }
}
