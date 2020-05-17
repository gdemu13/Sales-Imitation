using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SI.Domain.Abstractions.Repositories;

namespace SI.Infrastructure.DAL.Repository
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class, IRepository<T>
    {
        private readonly IConfiguration _config;

        public RepositoryBase(IConfiguration config)
        {
            _config = config;
        }

        protected IDbConnection Connection
        {
            get
            {
                return _connection ?? new SqlConnection(_config.GetConnectionString("siconnectionstring"));
            }
        }

        protected IDbConnection _connection;
        protected IDbTransaction _transaction;

        protected bool _transactionStarted;

        public T StartTransaction(Action<T> act)
        {
            _transactionStarted = true;
            _connection = new SqlConnection(_config.GetConnectionString("siconnectionstring"));
            _connection.Open();
            _transaction = _connection.BeginTransaction();

            act(this as T);
            return this as T;
        }

        public void Commit()
        {
            _transaction.Commit();
            _connection.Close();
        }

        public R ContinueTransactionWith<R>(R repo, Action<R> act) where R : IRepository<R>
        {
            System.Console.WriteLine(repo == null  ? "aaaaaaaaa" : "oooooooo");
            System.Console.WriteLine(repo.GetType().Name);
            repo.GetType().GetField("_connection", (
                         BindingFlags.NonPublic |
                         BindingFlags.Instance)).SetValue(repo, _connection);

            repo.GetType().GetField("_transaction", (
            BindingFlags.NonPublic |
            BindingFlags.Instance)).SetValue(repo, _transaction);

            act(repo);
            return repo;
        }

        // public C StartTransaction()
        // {
        //     _connection = new SqlConnection(_config.GetConnectionString("siconnectionstring"));
        //     _transaction = _connection.BeginTransaction();
        //     return this as C;
        // }

        // public R ContinueTransactionWith<R>(R repo) where R : IRepository<T>
        // {
        //     // (repo as RepositoryBase<T>)._connection = _connection;
        //     // (repo as RepositoryBase<T>)._transaction = _transaction;
        //     // return repo;
        //     return null;
        // }
    }
}