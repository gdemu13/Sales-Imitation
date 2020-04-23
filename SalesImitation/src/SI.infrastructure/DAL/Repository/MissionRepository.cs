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

        public async Task<Mission> Get (Guid ID) {
            Mission mission = null;
            return await Task.FromResult(mission);
        }

        public async Task<IEnumerable<Mission>> GetAll () {
            IEnumerable<Mission> res = null;
            return await Task.FromResult(res);
        }

        public async Task<Result> InsertIfLast (Mission mission, DateTime checkDate) {
            return await Task.FromResult(Result.CreateSuccessReqest());
        }

        public async Task<Result> Update (Guid id, Mission mission, DateTime checkDate) {
            return await Task.FromResult(Result.CreateSuccessReqest());
        }

        public async Task<DateTime> GetLastUpdateDate () {
            DateTime res = DateTime.Now;
            return await Task.FromResult(res);
        }

        public async Task<int> GetLastRoundNumber () {
            int res = 0;
            return await Task.FromResult(res);
        }

        public async Task<IEnumerable<Mission>> GetByPriceRange (decimal from, decimal to) {
            IEnumerable<Mission> res = null;
            return await Task.FromResult(res);
        }
    }
}