using System;
using System.Data;

namespace FCommerce.Core.UnitOfWork
{
    internal interface IUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }

        T Transaction<T>(Func<IDbTransaction, T> query);

        IDbTransaction BeginTransaction();

        void Commit();

        void Rollback();
    }
}