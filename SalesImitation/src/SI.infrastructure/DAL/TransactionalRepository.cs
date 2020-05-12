using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SI.Common.Models;

namespace SI.Infrastructure.DAL
{
    public class TransactionlRepository
    {
        private readonly IConfiguration _config;

        public TransactionlRepository(IConfiguration config)
        {
            _config = config;
            _connection = new SqlConnection(_config.GetConnectionString("siconnectionstring"));
        }

        private readonly IDbConnection _connection;

        private IDbConnection Connection
        {
            get
            {
                return _connection;
            }
        }

        public void StartTransaction(params Func<Result>[] acts)
        {
            using (var transaction = Connection.BeginTransaction())
            {
                try
                {
                   foreach(var act in acts)
                       act();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }

                transaction.Commit();
            }
        }
    }
}