using System;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;
using SI.Common.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace SI.Infrastructure.DAL.Repository {
    public class PlayerRepository : IPlayerRepository {
        private ICollection<Player> _db = new List<Player>();


        public Player GetPlayer(Guid id){
            return _db.FirstOrDefault(p => p.ID == id);
        }

        public async Task<Result> SavePlayer(Player player){
            _db.Add(player);
            return await Task.FromResult<Result> (Result.CreateSuccessReqest());
        }

        public async Task<IEnumerable<Player>> GetTopPlayersByScoreAsync(int n) {
            return await Task.FromResult<IEnumerable<Player>>(_db.Take(n));
        }
    }
}