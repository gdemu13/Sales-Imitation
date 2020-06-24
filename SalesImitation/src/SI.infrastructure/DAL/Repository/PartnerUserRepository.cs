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
    public class PartnerUserRepository : IPartnerUserRepository
    {
        private readonly IConfiguration _config;

        public PartnerUserRepository(IConfiguration config)
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

        public async Task<PartnerUser> Get(Guid id)
        {
            string sql = @"SELECT pu.*, p.Name as 'PartnerName' FROM PartnerUsers pu
                        INNER JOIN Partners p
                        ON p.ID = pu.PartnerID Where ID = @ID;";
            PartnerUser partnerUser = null;
            using (var connection = Connection)
            {
                var res = await connection.QueryFirstOrDefaultAsync(sql, new { ID = id });
                if (res != null)
                {
                    partnerUser = new PartnerUser(
                     res.ID, res.Username, new PartnerUserHashedPassword(res.PasswordHash),
                             res.Fullname, new PartnerUserPartner(res.PartnerID, res.PartnerName)
                   );
                }
            }
            return partnerUser;
        }

         public async Task<PartnerUser> GetByUsername(string username)
        {
            string sql = @"SELECT pu.*, p.Name as 'PartnerName' FROM PartnerUsers pu
                        INNER JOIN Partners p
                        ON p.ID = pu.PartnerID Where Username = @Username;";
            PartnerUser partnerUser = null;
            using (var connection = Connection)
            {
                var res = await connection.QueryFirstOrDefaultAsync(sql, new { Username = username });
                if (res != null)
                {
                    partnerUser = new PartnerUser(
                     res.ID, res.Username, new PartnerUserHashedPassword(res.PasswordHash),
                             res.Fullname, new PartnerUserPartner(res.PartnerID, res.PartnerName)
                   );
                }
            }
            return partnerUser;
        }

        public async Task<IEnumerable<PartnerUser>> GetByPartner(Guid partnerID)
        {
            string sql = @"SELECT pu.*, p.Name as 'PartnerName' FROM PartnerUsers pu
INNER JOIN Partners p
ON p.ID = pu.PartnerID Where pu.PartnerID = @ID;";
            IEnumerable<PartnerUser> partnerUsers = null;
            using (var connection = Connection)
            {
                var result = await connection.QueryAsync(sql, new { ID = partnerID });
                if (result != null)
                {
                    partnerUsers = result.Select(res =>
                        new PartnerUser(
                    res.ID, res.Username, new PartnerUserHashedPassword(res.PasswordHash),
                            res.Fullname, new PartnerUserPartner(res.PartnerID, res.PartnerName)));
                }
            }
            return partnerUsers;
        }

        public async Task<Result> Insert(PartnerUser partnerUser)
        {
            string sql = @"INSERT INTO [dbo].[PartnerUsers]
           ([ID]
           ,[Username]
           ,[PasswordHash]
           ,[Fullname]
           ,[PartnerID])
     VALUES
            (@ID
           ,@Username
           ,@PasswordHash
           ,@Fullname
           ,@PartnerID)";
            using (var connection = Connection)
            {
                var res = await connection.ExecuteAsync(sql, new {
                    ID = partnerUser.ID,
                    Username = partnerUser.Username,
                    PasswordHash = partnerUser.PasswordHash.Value,
                    Fullname = partnerUser.Fullname,
                    PartnerID = partnerUser.Partner.ID,
                    });
            }
            return Result.CreateSuccessReqest();
        }

        public Task<Result> Update(Guid id, PartnerUser partnerUser)
        {
            throw new NotImplementedException();
        }
    }
}