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

namespace SI.Infrastructure.DAL.Repository {
    public class MissionRepository : IMissionRepository {
        private readonly IConfiguration _config;

        public MissionRepository (IConfiguration config) {
            _config = config;
        }

        private IDbConnection Connection {
            get {
                return new SqlConnection (_config.GetConnectionString ("siconnectionstring"));
            }
        }

        public async Task<Mission> Get (Guid id) {
            string sql = "SELECT * From Missions Where ID = @ID;";
            Mission mission = null;
            using (var connection = Connection) {
                var res = await connection.QueryFirstOrDefaultAsync (sql, new { ID = id });
                if (res != null) {
                    mission = new Mission (res.ID,
                        res.Name,
                        res.Description,
                        res.Level,
                        res.PriceFrom,
                        res.PriceTo);
                }
            }
            return mission;
        }

        public async Task<IEnumerable<Mission>> GetAll () {
            string sql = "SELECT * From Missions Order By Ordering;";
            IEnumerable<Mission> missions = null;
            using (var connection = Connection) {
                var res = await connection.QueryAsync (sql);
                if (res != null) {
                    missions = res.Select (r => new Mission (r.ID,
                        r.Name,
                        r.Description,
                        r.Level,
                        r.PriceFrom,
                        r.PriceTo));
                }
            }
            return missions;
        }

        public async Task<Result> InsertIfLast (Mission mission, DateTime checkDate) {
            var sql = @"IF (SELECT count(ID) Level FROM Missions) = @Level - 1
                        INSERT INTO Missions (ID, Name, Description, Level, PriceFrom, PriceTo, LastUpdateDate)
                        VALUES (@ID, @Name, @Description, @Level, @PriceFrom, @PriceTo, @LastUpdateDate);";
            using (var connection = Connection) {
                var res = await connection.ExecuteAsync (sql, new {
                    ID = mission.ID,
                        Name = mission.Name,
                        Description = mission.Description,
                        Level = mission.Level,
                        PriceFrom = mission.PriceRange.From,
                        PriceTo = mission.PriceRange.To,
                        LastUpdateDate = DateTime.Now,
                });
            }
            return await Task.FromResult (Result.CreateSuccessReqest ());
        }

        public async Task<Result> Update (Guid id, Mission mission, DateTime checkDate) {
            var sql = @"UPDATE Missions
            SET
            Name = @Name,
            Description = @Description,
            Level = @Level,
            PriceFrom = @PriceFrom,
            PriceTo = @PriceTo,
            LastUpdateDate = @LastUpdateDate
            where ID = @ID";

            using (var connection = Connection) {
                var res = await connection.ExecuteAsync (sql, new {
                    ID = mission.ID,
                        Name = mission.Name,
                        Description = mission.Description,
                        Level = mission.Level,
                        PriceFrom = mission.PriceRange.From,
                        PriceTo = mission.PriceRange.To,
                        LastUpdateDate = DateTime.Now,
                });
            }
            return await Task.FromResult (Result.CreateSuccessReqest ());
        }

        public async Task<DateTime> GetLastUpdateDate () {
            string sql = "SELECT TOP 1 LastUpdateDate From Missions order by LastUpdateDate desc;";
            DateTime res = DateTime.Now;
            using (var connection = Connection) {
                res = await connection.QueryFirstOrDefaultAsync<DateTime> (sql);
            }

            return res;
        }

        public async Task<int> GetLastLevelNumber () {
            string sql = "SELECT TOP 1 Level From Missions order by Level desc;";
            int res = 0;
            using (var connection = Connection) {
                res = await connection.QueryFirstOrDefaultAsync<int> (sql);
            }

            return res;
        }

        public async Task<IEnumerable<Mission>> GetByPriceRange (decimal from, decimal to) {
          string sql = @"SELECT * From Missions where (@from <= PriceFrom AND  @to >= PriceFrom)
                                                    OR (@from >= PriceFrom AND @from <= PriceTo)
          Order By Ordering;";
            IEnumerable<Mission> missions = null;
            using (var connection = Connection) {
                var res = await connection.QueryAsync (sql, new {
                    from = from,
                    to = to,
                });
                if (res != null) {
                    missions = res.Select (r => new Mission (r.ID,
                        r.Name,
                        r.Description,
                        r.Level,
                        r.PriceFrom,
                        r.PriceTo));
                }
            }
            return missions;
        }
    }
}