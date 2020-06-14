using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using SI.Application.Contents;
using SI.Application.FAQs;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;

namespace SI.Infrastructure.DAL.Repository
{
    public class FAQsReposiotry : IFAQsRepository
    {
        private readonly IConfiguration _config;

        public FAQsReposiotry(IConfiguration config)
        {
            _config = config;
        }

        private IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("siconnectionstring"));
            }
        }

        public async Task<FAQModel> Get(Guid id)
        {
            string sql = "SELECT * From FAQs Where ID = @ID;";
            FAQModel faqItem = null;
            using (var connection = Connection)
            {
                faqItem = await connection.QueryFirstOrDefaultAsync<FAQModel>(sql, new { ID = id });
            }
            return faqItem;
        }

        public async Task<IEnumerable<FAQModel>> GetAll()
        {
            string sql = "SELECT * From FAQs;";
            IEnumerable<FAQModel> faq = null;
            using (var connection = Connection)
            {
                faq = await connection.QueryAsync<FAQModel>(sql);
            }
            return faq;
        }

        public async Task<Result> Save(FAQModel faqItem)
        {
            if (await Get(faqItem.ID) == null)
                return await Insert(faqItem);
            else
                return await Update(faqItem);
        }


        public async Task<Result> Insert(FAQModel faqItem)
        {
            string sql = "INSERT INTO FAQs (ID, Name, Value) Values (@ID, @Name,@Value);";

            using (var connection = Connection)
            {
                var affectedRows = await connection.ExecuteAsync(sql,
                    new
                    {
                        ID = Guid.NewGuid(),
                        Name = faqItem.Name,
                        Value = faqItem.Value,
                    });
            }

            return await Task.FromResult(Result.CreateSuccessReqest());
        }

        public async Task<Result> Update(FAQModel faqItem)
        {

            string sql = @"UPDATE FAQs SET
            Value = @Value,
            Name = @Name
            where ID = @ID;";

            using (var connection = Connection)
            {
                var affectedRows = await connection.ExecuteAsync(sql,
                    new
                    {
                        ID = faqItem.ID,
                        Name = faqItem.Name,
                        Value = faqItem.Value,
                    });
            }

            return await Task.FromResult(Result.CreateSuccessReqest());
        }

        public async Task<Result> Remove(Guid id)
        {
            string sql = @"DELETE FROM FAQs
            where ID = @ID;";

            using (var connection = Connection)
            {
                var affectedRows = await connection.ExecuteAsync(sql,
                    new
                    {
                        ID = id,
                    });
            }

            return await Task.FromResult(Result.CreateSuccessReqest());
        }
    }
}