using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;

namespace SI.Infrastructure.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _config;

        public UserRepository(IConfiguration config)
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

        public async Task<User> GetByID(Guid id)
        {
            string sql = "SELECT * From Users Where ID = @ID;";
            User user = null;
            using (var connection = Connection)
            {
                var res = await connection.QueryFirstOrDefaultAsync(sql, new { ID = id });
                if (res != null)
                {
                    var pass = new HashedPassword(res.PasswordHash);
                    user = new User(res.ID, res.UserName, pass, res.LastUpdateDate);
                }
            }
            return user;
        }

        public async Task<User> GetByUserName(string username)
        {
            string sql = "SELECT * From Users Where UserName = @UserName;";
            User user = null;
            using (var connection = Connection)
            {
                var res = await connection.QueryFirstOrDefaultAsync(sql, new
                {
                    UserName = username,
                });
                if (res != null)
                {
                    var pass = new HashedPassword(res.PasswordHash);
                    user = new User(res.ID, res.UserName, pass, res.LastUpdateDate);
                }
            }
            return user;
        }

        public async Task<Result> Insert(User user)
        {
            string sql = "INSERT INTO Users (ID, UserName, PasswordHash, LastUpdateDate) Values (@ID, @UserName, @PasswordHash, @LastUpdateDate);";

            using (var connection = Connection)
            {
                var affectedRows = await connection.ExecuteAsync(sql,
                    new
                    {
                        ID = user.ID,
                        UserName = user.UserName,
                        PasswordHash = user.PasswordHash.Value,
                        LastUpdateDate = user.LastUpdateDate,
                    });
            }

            return await Task.FromResult(Result.CreateSuccessReqest());
        }


        public async Task<Result> UpdatePassword(Guid ID, string newPasswordHash, DateTime checkDate)
        {
            string sql = @"UPDATE Users SET  PasswordHash = @PasswordHash
                               where ID = @ID AND LastUpdateDate = @CheckDate;";

            using (var connection = Connection)
            {
                var affectedRows = await connection.ExecuteAsync(sql,
                    new
                    {
                        ID = ID,
                        PasswordHash = newPasswordHash,
                        LastUpdateDate = DateTime.Now,
                        CheckDate = checkDate,
                    });
            }

            return await Task.FromResult(Result.CreateSuccessReqest());
        }

    }
}