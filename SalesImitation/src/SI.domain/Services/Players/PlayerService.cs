using System;
using System.Threading.Tasks;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;

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

            player.SpendCoins(hours, "BuyExtraTime");
            mission.AddExtraHours(hours);

            //DIDI TODO:
            await playerRepository.UpdatePlayer(player, playerUpdateDate.Value);
            return await currentMissionRepository.UpdateIfNotChanged(mission.ID, mission, missionUpdateDate.Value);
        }
    }
}