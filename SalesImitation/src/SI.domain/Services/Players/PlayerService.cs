using System;
using System.Threading.Tasks;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;

namespace SI.Domain.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository playerRepository;
        private readonly ICurrentMissionRepository currentMissionRepository;

        public PlayerService(IPlayerRepository playerRepository, ICurrentMissionRepository currentMissionRepository)
        {
            this.playerRepository = playerRepository;
            this.currentMissionRepository = currentMissionRepository;
        }

        public async Task<Result> BuyExtraTime(Guid playerID, int hours)
        {
            var (player, playerUpdateDate) = await playerRepository.GetByID(playerID);
            var (mission, missionUpdateDate) = await currentMissionRepository.GetActiveByUser(playerID);
            //TODO" every repository should check and update date
            player.SpendCoins(hours, "BuyExtraTime");
            mission.AddExtraHours(hours);

            // playerRepository.StartTransaction(a => forTest(a, player, playerUpdateDate))
            //                 .ContinueTransactionWith(currentMissionRepository, a => a.UpdateIfNotChanged(mission.ID, mission, missionUpdateDate.Value))
            //                 .Commit();

            //DIDI TODO: trakzaciebi
            await playerRepository.UpdatePlayer(player, playerUpdateDate.Value);
            return await currentMissionRepository.UpdateIfNotChanged(mission.ID, mission, missionUpdateDate.Value);
        }

        public async Task<Result> SkipMission(Guid playerID)
        {
            var (player, playerUpdateDate) = await playerRepository.GetByID(playerID);
            var (mission, missionUpdateDate) = await currentMissionRepository.GetActiveByUser(playerID);
            //TODO: add transaction
            player.SpendCoins(Math.Min(mission.Product1.ExpectedCoin, mission.Product2.ExpectedCoin), "SKIP_MISSION");
            player.LevelUp();
            mission.SkipMission();

            await playerRepository.UpdatePlayer(player, playerUpdateDate.Value);
            return await currentMissionRepository.UpdateIfNotChanged(mission.ID, mission, missionUpdateDate.Value);
        }

        private static Task<Result> forTest(IPlayerRepository a, Player player, DateTime? playerUpdateDate)
        {
            return a.UpdatePlayer(player, playerUpdateDate.Value);
        }
    }
}