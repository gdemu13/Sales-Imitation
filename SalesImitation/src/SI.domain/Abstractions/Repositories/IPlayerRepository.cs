using System;
using SI.Domain.Entities;
using System.Threading.Tasks;
using SI.Common.Models;
using System.Collections.Generic;

namespace SI.Domain.Abstractions.Repositories {
    public interface IPlayerRepository {
        Player GetPlayer(Guid id);
        Task<Result> SavePlayer(Player id);
        Task<IEnumerable<Player>> GetTopPlayersByScoreAsync(int n);
    }
}