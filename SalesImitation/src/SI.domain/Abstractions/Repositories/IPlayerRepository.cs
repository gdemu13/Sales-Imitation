using System;
using SI.Domain.Entities;
using System.Threading.Tasks;
using SI.Common.Models;
using System.Collections.Generic;

namespace SI.Domain.Abstractions.Repositories {
    public interface IPlayerRepository {
        Task<(Player, DateTime?)> GetByID(Guid id);
        Task<(Player, DateTime?)> GetByUsername(string username);
        Task<Result> InsertPlayerIfUnique(Player id);
        Task<Result> UpdatePlayer(Player player, DateTime lastUpdateDate);
         Task<IEnumerable<Player>> GetTopPlayersByScoreAsync(int n);
    }
}