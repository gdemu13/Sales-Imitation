using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using SI.Application.Contents;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;

namespace SI.Infrastructure.DAL.Repository
{
    public class ContentRepository : IContentRepository
    {
        private readonly IConfiguration _config;

        public ContentRepository(IConfiguration config)
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

        public async Task<ContentModel> Get(string name)
        {
            string sql = "SELECT * From Contents Where Name = @Name;";
            ContentModel content = null;
            using (var connection = Connection)
            {
                content = await connection.QueryFirstOrDefaultAsync<ContentModel>(sql, new { Name = name });
            }
            return content;
        }

        public async Task<Result> Save(ContentModel content)
        {
            if (await Get(content.Name) == null)
                return await Insert(content);
            else
                return await Update(content);
        }


        public async Task<Result> Insert(ContentModel content)
        {
            string sql = "INSERT INTO Contents (Name, Value) Values (@Name,@Value);";

            using (var connection = Connection)
            {
                var affectedRows = await connection.ExecuteAsync(sql,
                    new
                    {
                        Name = content.Name,
                        Value = content.Value,
                    });
            }

            return await Task.FromResult(Result.CreateSuccessReqest());
        }

        public async Task<Result> Update(ContentModel content)
        {

            string sql = @"UPDATE Contents SET
            Value = @Value
            where Name = @Name;";

            using (var connection = Connection)
            {
                var affectedRows = await connection.ExecuteAsync(sql,
                    new
                    {
                        Name = content.Name,
                        Value = content.Value,
                    });
            }

            return await Task.FromResult(Result.CreateSuccessReqest());
        }
    }
}