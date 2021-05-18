using Microsoft.EntityFrameworkCore.Storage;
using System;
using CenedQualificando.Domain.Interfaces.UoW;
using CenedQualificando.Infra.Context;

namespace CenedQualificando.Infra.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntityContext _entityContext;
        private IDbContextTransaction _transaction;

        public UnitOfWork(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }

        public int Commit()
        {
            return _entityContext.SaveChanges();
        }

        /// <summary>
        /// Abre a Transação (obs.: dentros do bloco de transaction deve-se usar o comando "Commit()" e por último o "CommitTransaction"
        /// </summary>
        public void BeginTransaction()
        {
            _transaction = _entityContext.Database.BeginTransaction();
        }

        /// <summary>
        /// Salva a Transação (obs.: Consolida e salva no banco de dados todas as alterações comitadas com o comando "Commit()").
        /// </summary>
        public void CommitTransaction()
        {
            _transaction.Commit();
        }

        /// <summary>
        /// Reverte as alterações de uma tranação
        /// </summary>
        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            _entityContext.Dispose();

            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }

            GC.SuppressFinalize(this);
        }
    }
}
