using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;

namespace SI.Infrastructure.DAL.Repository
{
    public class CurrentMissionRepository : RepositoryBase<ICurrentMissionRepository>, ICurrentMissionRepository
    {

        public CurrentMissionRepository(IConfiguration config) : base(config)
        {
        }


        public async Task<IEnumerable<CurrentMission>> GetRange(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> Insert(CurrentMission mission)
        {
            //TODO active unda gamovtvalo da shevamowmo chaweramde
            // var sql = @"IF (SELECT count(ID) Level FROM Missions) = @Level - 1
            var sql = @" insert into CurrentMissions
           ([ID],[Name],[Description],[Level],[PlayerID],[Point],[Prod1ID],[Prod1Name],[Prod1Desc],
           [Prod1PartnerName],[Prod1PartnerAddress],[Prod1Benefits],[Prod2ID],[Prod2Name],
           [Prod2Desc],[Prod2PartnerName],[Prod2PartnerAddress],[Prod2Benefits],[CategoryID],
           [CategoryName],[PromoCode],[Status],[Duration],[StartedDate],[FinishedDate],[LastUpdateDate], [AddedHours], [EarnedCoints], [CategoryUpdated])
     VALUES
           (
                @ID, @Name,@Description,@Level,@PlayerID,@Point,@Prod1ID,@Prod1Name,@Prod1Desc,@Prod1PartnerName,
                @Prod1PartnerAddress,@Prod1Benefits,@Prod2ID,@Prod2Name,@Prod2Desc,@Prod2PartnerName,
                @Prod2PartnerAddress,@Prod2Benefits,@CategoryID,@CategoryName,@PromoCode,@Status,
                @Duration,@StartedDate,@FinishedDate,@LastUpdateDate, @AddedHours, @EarnedCoints, @CategoryUpdated
           )";
            using (var connection = Connection)
            {
                var status = mission.GetType()
                   .GetField("_status", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                  .GetValue(mission);

                var res = await connection.ExecuteAsync(sql, new
                {
                    ID = mission.ID,
                    Name = mission.Name,
                    Description = mission.Description,
                    Level = mission.Level,
                    PlayerID = mission.Player.ID,
                    Point = mission.EarnedCoints, //TODO titoeuli produqtisac unda iyos
                    Prod1ID = mission.Product1.ID,
                    Prod1Name = mission.Product1.Name,
                    Prod1Desc = mission.Product1.Description,
                    Prod1PartnerName = mission.Product1.PartnerName,
                    Prod1PartnerAddress = mission.Product1.PartnetaAddress,
                    Prod1Benefits = mission.Product1.Benefits,
                    Prod2ID = mission.Product2.ID,
                    Prod2Name = mission.Product2.Name,
                    Prod2Desc = mission.Product2.Description,
                    Prod2PartnerName = mission.Product2.PartnerName,
                    Prod2PartnerAddress = mission.Product2.PartnerName,
                    Prod2Benefits = mission.Product2.Benefits,
                    CategoryID = mission.Category.ID,
                    CategoryName = mission.Category.Name,
                    PromoCode = mission.PromoCode,
                    Status = status,
                    Duration = mission.DurationHours,
                    StartedDate = mission.StartedDate,
                    FinishedDate = mission.FinishedDate,
                    LastUpdateDate = DateTime.Now,
                    AddedHours = mission.AddedHours,
                    EarnedCoints = mission.EarnedCoints,
                    CategoryUpdated = mission.CategoryUpdated
                });
            }
            return await Task.FromResult(Result.CreateSuccessReqest());
        }

        public async Task<Result> UpdateIfNotChanged(Guid id, CurrentMission mission, DateTime checkDate)
        {
            //TODO active unda gamovtvalo da shevamowmo chaweramde
            // var sql = @"IF (SELECT count(ID) Level FROM Missions) = @Level - 1
            var sql = @"UPDATE CurrentMissions SET
                    [Name] = @ame, [Description] = @escription, [Level] = @evel,
                    [PlayerID] = @layerID, [Point] = @oint, [Prod1ID] = @rod1ID, [Prod1Name] = @rod1Name,
                    [Prod1Desc] = @rod1Desc, [Prod1PartnerName] = @rod1PartnerName,
                    [Prod1PartnerAddress] = @rod1PartnerAddress, [Prod1Benefits] = @rod1Benefits,
                    [Prod2ID] = @rod2ID, [Prod2Name] = @rod2Name, [Prod2Desc] = @rod2Desc,
                    [Prod2PartnerName] = @rod2PartnerName, [Prod2PartnerAddress] = @rod2PartnerAddress,
                    [Prod2Benefits] = @rod2Benefits, [CategoryID] = @ategoryID, [CategoryName] = @ategoryName,
                    [PromoCode] = @romoCode, [Status] = @tatus, [Duration] = @uration,
                    [StartedDate] = @tartedDate, [FinishedDate] = @inishedDate,
                    [LastUpdateDate] = @astUpdateDate, [AddedHours] = @ddedHours,
                    [EarnedCoints] = @arnedCoints, [CategoryUpdated] = @ategoryUpdated where [ID] = @ID";

            using (var connection = Connection)
            {
                var status = mission.GetType()
                   .GetField("_status", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                  .GetValue(mission);

                var res = await connection.ExecuteAsync(sql, new
                {
                    ID = mission.ID,
                    ame = mission.Name,
                    escription = mission.Description,
                    evel = mission.Level,
                    layerID = mission.Player.ID,
                    oint = mission.EarnedCoints, //TODO titoeuli produqtisac unda iyos
                    rod1ID = mission.Product1.ID,
                    rod1Name = mission.Product1.Name,
                    rod1Desc = mission.Product1.Description,
                    rod1PartnerName = mission.Product1.PartnerName,
                    rod1PartnerAddress = mission.Product1.PartnetaAddress,
                    rod1Benefits = mission.Product1.Benefits,
                    rod2ID = mission.Product2.ID,
                    rod2Name = mission.Product2.Name,
                    rod2Desc = mission.Product2.Description,
                    rod2PartnerName = mission.Product2.PartnerName,
                    rod2PartnerAddress = mission.Product2.PartnerName,
                    rod2Benefits = mission.Product2.Benefits,
                    ategoryID = mission.Category.ID,
                    ategoryName = mission.Category.Name,
                    romoCode = mission.PromoCode,
                    tatus = status,
                    uration = mission.DurationHours,
                    tartedDate = mission.StartedDate,
                    inishedDate = mission.FinishedDate,
                    astUpdateDate = DateTime.Now,
                    ddedHours = mission.AddedHours,
                    arnedCoints = mission.EarnedCoints,
                    ategoryUpdated = mission.CategoryUpdated
                }, _transaction);
            }
            return await Task.FromResult(Result.CreateSuccessReqest());
        }

        public async Task<CurrentMission> Get(Guid ID)
        {
            string sql = "SELECT * From CurrentMissions Where ID = @ID;";
            CurrentMission currentMission = null;
            using (var connection = Connection)
            {
                var res = await connection.QueryFirstOrDefaultAsync(sql, new { ID = ID });
                if (res != null)
                {
                    var currentMissionProduct1 = new CurrentMissionProduct(res.Prod1ID, res.Prod1Name, res.Prod1Desc,
                                    res.Prod1PartnerName, res.Prod1PartnerAddress, res.Prod1Benefits, res.Prod1Coins);

                    var currentMissionProduct2 = new CurrentMissionProduct(res.Prod2ID, res.Prod2Name, res.Prod2Desc,
                                    res.Prod2PartnerName, res.Prod2PartnerAddress, res.Prod2Benefits, res.Prod2Coins);

                    var currentMissionCategory = new CurrentMissionCategory(res.categoryID, res.categoryName);


                    var curMission = (CurrentMission)Activator.CreateInstance(typeof(CurrentMission), true);

                    curMission.GetType()
                    .GetProperty("asd", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                    // var curMission = new CurrentMission(res.ID, res.Name, res.Description, res.Level, currentMissionProduct1, currentMissionProduct2, currentMissionCategory, res.duration);

                    // if (string.IsNullOrEmpty(!res.PromoCode))
                    //     curMission.SetPromoCode(res.PromoCode);

                    // if(res.Status >= (int)CurrentMissionStatuses.Active)
                    //     curMission.Start(res.StartedDate);

                    // if(res.Status == (int)CurrentMissionStatuses.Finished)
                    //     curMission.SellProduct(res.PromoCode,  res.StartedDate);

                    curMission.Status = (CurrentMissionStatuses)res.Status;
                }
            }
            return currentMission;
        }

        public async Task<(CurrentMission, DateTime?)> GetActiveByUser(Guid ID)
        {
            string sql = @"select c.*, p.FirstName + ' ' + p.LastName as PlayerFullName,
                        p.Level as PlayerLevel from CurrentMissions c
                        left join Players p
                        on c.PlayerID = p.ID
                        Where PlayerID = @ID
                        and c.Status = @status
                        and dateadd(HOUR, c.Duration + c.AddedHours, c.StartedDate) > @NowDate;"; //TODO active unda gamovtvalo
            CurrentMission currentMission = null;
            DateTime? lastUpdateDate = null;
            using (var connection = Connection)
            {
                var res = await connection.QueryFirstOrDefaultAsync(sql, new
                {
                    ID = ID,
                    Status = CurrentMissionStatuses.Active,
                    NowDate = DateTime.Now
                });
                if (res != null)
                {
                    // System.Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6}", res.Prod1ID, res.Prod1Name, res.Prod1Desc,
                    //                 res.Prod1PartnerName, res.Prod1PartnerAddress, res.Prod1Benefits, res.Point);
                    var player = new CurrentMissionPlayer(res.PlayerID, res.PlayerFullName, res.PlayerLevel);

                    var currentMissionProduct1 = new CurrentMissionProduct(res.Prod1ID, res.Prod1Name, res.Prod1Desc,
                                    res.Prod1PartnerName, res.Prod1PartnerAddress, res.Prod1Benefits, res.Point);  //TODO: point unda qondes titoeul produqts tavisi

                    var currentMissionProduct2 = new CurrentMissionProduct(res.Prod2ID, res.Prod2Name, res.Prod2Desc,
                                    res.Prod2PartnerName, res.Prod2PartnerAddress, res.Prod2Benefits, res.Point); //TODO: point unda qondes titoeul produqts tavisi

                    var currentMissionCategory = new CurrentMissionCategory(res.CategoryID, res.CategoryName);



                    currentMission = (CurrentMission)Activator.CreateInstance(typeof(CurrentMission), true);

                    currentMission.GetType()
                    .GetProperty("ID", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                   .SetValue(currentMission, res.ID, null);

                    currentMission.GetType()
                     .GetProperty("Name", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .SetValue(currentMission, res.Name, null);

                    currentMission.GetType()
                  .GetProperty("Description", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                 .SetValue(currentMission, res.Description, null);

                    currentMission.GetType()
                     .GetProperty("Level", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .SetValue(currentMission, res.Level, null);

                    currentMission.GetType()
                     .GetField("_status", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .SetValue(currentMission, res.Status);

                    currentMission.GetType()
                     .GetProperty("Product1", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .SetValue(currentMission, currentMissionProduct1, null);

                    currentMission.GetType()
                     .GetProperty("Product2", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .SetValue(currentMission, currentMissionProduct2, null);

                    currentMission.GetType()
                     .GetProperty("Category", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .SetValue(currentMission, currentMissionCategory, null);

                    currentMission.GetType()
                     .GetProperty("Player", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .SetValue(currentMission, player, null);

                    currentMission.GetType()
                     .GetProperty("StartedDate", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .SetValue(currentMission, res.StartedDate, null);

                    currentMission.GetType()
                     .GetProperty("DurationHours", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .SetValue(currentMission, res.Duration, null);

                    currentMission.GetType()
                     .GetProperty("PromoCode", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .SetValue(currentMission, res.PromoCode, null);

                    currentMission.GetType()
                    .GetProperty("AddedHours", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                   .SetValue(currentMission, res.AddedHours, null);

                    currentMission.GetType()
                    .GetProperty("EarnedCoints", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                   .SetValue(currentMission, res.EarnedCoints, null);


                    currentMission.GetType()
                    .GetProperty("CategoryUpdated", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                   .SetValue(currentMission, res.CategoryUpdated, null);

                    lastUpdateDate = res.LastUpdateDate;
                }
            }
            return (currentMission, lastUpdateDate);
        }


        public async Task<CurrentMission> GetByUser(Guid id)
        {
            //TODO
            return null;
            throw new NotImplementedException();
        }
    }
}