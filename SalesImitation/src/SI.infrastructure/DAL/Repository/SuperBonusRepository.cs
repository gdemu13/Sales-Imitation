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
    public class SuperBonusRepository : ISuperBonusRepository
    {
        private readonly IConfiguration _config;

        public SuperBonusRepository(IConfiguration config)
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

        public async Task<Result> InsertSuperBonusBase(SuperBonus bonus)
        {

            string sql = "INSERT INTO SuperBonuses (ID, BaseAmount, Status) Values (@ID, @Amount, @Status);";

            using (var connection = Connection)
            {
                var affectedRows = await connection.ExecuteAsync(sql,
                    new
                    {
                        ID = bonus.ID,
                        Amount = bonus.BaseAmount,
                        Status = bonus.Status
                    });
            }

            return await Task.FromResult(Result.CreateSuccessReqest());
        }

        public async Task<Result> UpdateSuperBonusBase(Guid id, decimal amount)
        {
            string sql = "UPDATE SuperBonuses set BaseAmount = @Amount where ID = @ID;";

            using (var connection = Connection)
            {
                var affectedRows = await connection.ExecuteAsync(sql, new { ID = id, Amount = amount });
            }

            return await Task.FromResult(Result.CreateSuccessReqest());
        }

        public async Task<SuperBonus> GetPending()
        {
            string sql = "SELECT * FROM SuperBonuses WHERE Status = @Status;";
            SuperBonus bonus = null;
            using (var connection = Connection)
            {
                var res = await connection.QueryFirstOrDefaultAsync<SuperBonusTable>(sql, new { Status = SuperBonusStatuses.Pending });
                if (res != null)
                    bonus = new SuperBonus(res.ID, res.BaseAmount, res.Status);
            }
            return bonus;
        }

        public async Task<Result> UpdateStatus(Guid id, SuperBonusStatuses status)
        {
            string sql = "UPDATE SuperBonuses set Status = @Status where ID = @ID;";

            using (var connection = Connection)
            {
                var affectedRows = await connection.ExecuteAsync(sql, new
                {
                    ID = id,
                    Status = (int)status,
                });
            }

            return await Task.FromResult(Result.CreateSuccessReqest());
        }

        public async Task<SuperBonus> GetActive()
        {
            string sql = "SELECT * FROM SuperBonuses WHERE Status = @Status;";
            SuperBonus bonus = null;
            using (var connection = Connection)
            {
                var res = await connection.QueryFirstOrDefaultAsync<SuperBonusTable>(sql, new { Status = (int)SuperBonusStatuses.Active });
                if (res != null)
                    bonus = new SuperBonus(res.ID, res.BaseAmount, res.Status);
            }
            return bonus;
        }

        public async Task<Result> IncreaseBonus(decimal amount, string source)
        {
            // var bonus = _db.FirstOrDefault (d => d.Status == SuperBonusStatuses.Pending);
            // if (bonus != null)
            //     bonus.Increase (Guid.NewGuid (), amount, source);
            return await Task.FromResult(Result.CreateSuccessReqest());
        }

        private class SuperBonusTable
        {
            public Guid ID { get; set; }
            public decimal BaseAmount { get; set; }
            public SuperBonusStatuses Status { get; set; }
        }
    }
}