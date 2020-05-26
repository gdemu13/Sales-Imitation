using System;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;
using SI.Common.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Reflection;

namespace SI.Infrastructure.DAL.Repository
{
    public class PlayerRepository : RepositoryBase<IPlayerRepository>, IPlayerRepository
    {
        public PlayerRepository(IConfiguration config) : base(config)
        {
        }

        public async Task<(Player, DateTime?)> GetByID(Guid id)
        {
            string sql = "SELECT * From PLayers Where ID = @ID;";
            Player player = null;
            DateTime? lastUpdateDate = null;
            using (var connection = Connection)
            {
                var res = await connection.QueryFirstOrDefaultAsync(sql, new { ID = id });
                if (res != null)
                {
                    var pass = new PlayerHashedPassword(res.PasswordHash);
                    player = new Player(res.ID, res.Username, pass, res.Email, res.FirstName, res.LastName, res.Level, (PlayerAvatars)res.Avatar);

                    player.GetType()
               .GetProperty("Coins", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
              .SetValue(player, res.Coins, null);

                    lastUpdateDate = res.LastUpdateDate;
                }
            }
            return (player, lastUpdateDate);
        }

        public async Task<(Player, DateTime?)> GetByUsername(string username)
        {
            string sql = "SELECT * From Players Where Username = @Username;";
            Player player = null;
            DateTime? lastUpdateDate = null;
            using (var connection = Connection)
            {
                var res = await connection.QueryFirstOrDefaultAsync(sql, new { Username = username });
                if (res != null)
                {
                    var pass = new PlayerHashedPassword(res.PasswordHash);
                    player = new Player(res.ID, res.Username, pass, res.PlayerName, res.FirstName, res.LastName, res.Level, (PlayerAvatars)res.Avatar);
                    lastUpdateDate = res.LastUpdateDate;
                }
            }
            return (player, lastUpdateDate);
        }

        public async Task<Result> InsertPlayerIfUnique(Player player)
        {
            string sql = @"INSERT INTO Players (ID, Username, PasswordHash, FirstName, LastName, Email, LastUpdateDate, level, Coins, FacebookID, Avatar)
            Values (@ID, @Username, @PasswordHash, @FirstName, @LastName, @Email, @LastUpdateDate, @Level, @Coins, @FacebookID, @Avatar);";

            using (var connection = Connection)
            {
                var affectedRows = await connection.ExecuteAsync(sql,
                    new
                    {
                        ID = player.ID,
                        Username = player.Username,
                        PasswordHash = player.PasswordHash.Value,
                        FirstName = player.Firstname,
                        LastName = player.Lastname,
                        Email = player.Mail,
                        LastUpdateDate = DateTime.Now,
                        Level = player.CurrentLevel,
                        Coins = player.Coins,
                        FacebookID = player.FacebookID,
                        Avatar = (int)player.Avatar,
                    });
            }

            return await Task.FromResult(Result.CreateSuccessReqest());
        }

        public async Task<Result> UpdatePlayer(Player player, DateTime checkDate)
        {
            string sql = @"UPDATE Players SET  FirstName = @FirstName,
                                                LastName = @LastName,
                                                Email = @Email,
                                                Level = @Level,
                                                Coins = @Coins,
                                                Avatar = @Avatar,
                               where ID = @ID AND LastUpdateDate = @CheckDate;";

            using (var connection = Connection)
            {
                var affectedRows = await connection.ExecuteAsync(sql,
                    new
                    {
                        ID = player.ID,
                        FirstName = player.Firstname,
                        LastName = player.Lastname,
                        Email = player.Mail,
                        CheckDate = checkDate,
                        Level = player.CurrentLevel,
                        Coins = player.Coins,
                        Avatar = player.Avatar,
                    }, _transaction);
            }

            return await Task.FromResult(Result.CreateSuccessReqest());
        }

        public async Task<Result> UpdatePassword(Guid ID, string newPasswordHash, DateTime checkDate)
        {
            string sql = @"UPDATE Players SET  PasswordHash = @PasswordHash
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

        public async Task<IEnumerable<Player>> GetTopPlayersByScoreAsync(int n)
        {
            var result = new List<Player>();
            string sql = $"SELECT top {n} * From Players order by Coins desc;";
            using (var connection = Connection)
            {
                var lst = await connection.QueryAsync(sql, new { quantity = n });
                if (lst != null)
                {
                    Player player = null;
                    foreach (var res in lst)
                    {
                        var pass = new PlayerHashedPassword(res.PasswordHash);
                        player = new Player(res.ID, res.Username, pass, res.Email, res.FirstName, res.LastName, res.Level, (PlayerAvatars)res.Avatar);

                        player.GetType()
                                .GetProperty("Coins", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                                .SetValue(player, res.Coins, null);
                        result.Add(player);
                    }
                }
            }
            return result;
        }

        public async Task<Player> GetByFacebookID(string fbID)
        {
            string sql = "SELECT * From Players Where FacebookID = @ID;";
            Player player = null;
            using (var connection = Connection)
            {
                var res = await connection.QueryFirstOrDefaultAsync(sql, new { ID = fbID });
                if (res != null)
                {
                    var pass = new PlayerHashedPassword(res.PasswordHash);
                    player = new Player(res.ID, res.Username, pass, res.Email, res.FirstName, res.LastName, res.Level, (PlayerAvatars)res.Avatar);

                    player.GetType()
               .GetProperty("Coins", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
              .SetValue(player, res.Coins, null);
                }
            }
            return player;
        }


        //reports
        public async Task<(int, decimal)> GetPlayerPlaceInLeaderboard(Guid id)
        {
            string sql = @"WITH MyCte AS
                            (
                                select   ID, Coins,
                                        Place = row_number() OVER ( order by Coins desc)
                                from     Players
                            )
                            SELECT  Place, Coins
                            FROM    MyCte
                            where ID = @ID;";
            using (var connection = Connection)
            {
                var res = await connection.QueryFirstOrDefaultAsync(sql, new { ID = id });
                return ((int)res.Place, res.Coins);
            }
        }
    }
}