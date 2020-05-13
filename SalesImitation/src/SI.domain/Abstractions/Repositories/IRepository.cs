using System;

namespace SI.Domain.Abstractions.Repositories
{
    public interface IRepository<T>
    {
        T StartTransaction(Action<T> act);

        R ContinueTransactionWith<R>(R repo, Action<R> act) where R : IRepository<R>;

        void Commit();
    }
}