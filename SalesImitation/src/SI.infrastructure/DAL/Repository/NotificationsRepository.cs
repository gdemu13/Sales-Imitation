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
    public class NotificationRepository : INotificationRepository
    {
        private readonly IConfiguration _config;

        public NotificationRepository(IConfiguration config)
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

        public async Task<Notification> Get(Guid id)
        {
            string sql = "SELECT * From Notifications Where ID = @ID;";
            Notification notification = null;
            using (var connection = Connection)
            {
                var res = await connection.QueryFirstOrDefaultAsync(sql, new { ID = id });
                if (res != null)
                {
                    notification = new Notification(res.ID, res.PlayerID, res.Title, res.Description, (NotificationTypes)res.Type, res.Deadline, res.Seen);
                }
            }
            return notification;
        }

        public async Task<Result> Insert(Notification notification)
        {

            string sql = @"INSERT INTO Notifications (ID, Title, Description, Deadline, PlayerID, Type, Seen, LastUpdateDate)
                        Values (@ID, @Title, @Description, @Deadline, @PlayerID, @Type, @Seen, @LastUpdateDate);";

            using (var connection = Connection)
            {
                var affectedRows = await connection.ExecuteAsync(sql,
                    new
                    {
                        ID = notification.ID,
                        Title = notification.Title,
                        Description = notification.Description,
                        Deadline = notification.Deadline,
                        PlayerID = notification.PlayerID,
                        Type = (int)notification.Type,
                        Seen = 0,
                        LastUpdateDate = @DateTime.Now
                    });
            }

            return await Task.FromResult(Result.CreateSuccessReqest());
        }

        public async Task<Result> Update(Guid id, Notification notification)
        {

            string sql = @"UPDATE Categories SET
                        Title = @Title,
                        Description = @Description,
                        Deadline = @Deadline,
                        PlayerID = @PlayerID,
                        Type = @Type,
                        Seen = @Seen,
                        LastUpdateDate = @LastUpdateDate
            where ID = @ID;";

            using (var connection = Connection)
            {
                var affectedRows = await connection.ExecuteAsync(sql,
                    new
                    {
                        ID = id,
                        Title = notification.Title,
                        Description = notification.Description,
                        Deadline = notification.Deadline,
                        PlayerID = notification.PlayerID,
                        Type = (int)notification.Type,
                        Seen = notification.Seen,
                        LastUpdateDate = DateTime.Now
                    });
            }

            return await Task.FromResult(Result.CreateSuccessReqest());
        }

        public async Task<Result> SetIsActive(Guid id, bool isActive)
        {

            string sql = "UPDATE Categories SET IsActive = @IsActive where ID = @ID;";  //TODO paging

            using (var connection = Connection)
            {
                var affectedRows = await connection.ExecuteAsync(sql,
                    new
                    {
                        ID = id,
                        IsActive = isActive,
                    });
            }

            return await Task.FromResult(Result.CreateSuccessReqest());
        }

        public async Task<IEnumerable<Notification>> GetRange(int skip, int take, string searchWord)
        {
            string sql = "SELECT * From Categories Order By Ordering desc;";
            IEnumerable<Notification> notifications = null;
            using (var connection = Connection)
            {
                var res = await connection.QueryAsync(sql);
                if (res != null)
                {
                    notifications = res.Select(r =>
                    {
                        var c = new Notification(r.ID, r.PlayerID, r.Title, r.Description, (NotificationTypes)r.Type, r.Deadline, r.Seen);
                        return c;
                    });
                }
            }
            return notifications;
        }

        public Task<IEnumerable<Notification>> Count(string searchWord)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Notification>> GetUnseenByPlayer(Guid playerID)
        {
            string sql = "SELECT * From Notifications Where PlayerID = @PlayerID and Seen = 0 and Deadline > @Now;";
            IEnumerable<Notification> notifications = null;
            using (var connection = Connection)
            {
                var res = await connection.QueryAsync(sql, new { PlayerID = playerID, Now = DateTime.Now });
                if (res != null)
                {
                    notifications = res.Select(r =>
                    {
                        var c = new Notification(r.ID, r.PlayerID, r.Title, r.Description, (NotificationTypes)r.Type, r.Deadline, r.Seen);
                        return c;
                    });
                }
            }
            return notifications;
        }

        public async Task<Result> SetSeen(IEnumerable<Guid> ids)
        {
            string sql = @"UPDATE Notifications SET
                        Seen = 1,
                        LastUpdateDate = @LastUpdateDate
            where ID in @IDs;";

            using (var connection = Connection)
            {
                var affectedRows = await connection.ExecuteAsync(sql,
                   new
                   {
                       LastUpdateDate = DateTime.Now,
                       IDs = ids
                   });
            }

            return await Task.FromResult(Result.CreateSuccessReqest());
        }
    }
}