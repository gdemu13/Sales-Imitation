using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;

namespace SI.Infrastructure.DAL.Repository {
    public class SuperBonusRepository : ISuperBonusRepository {
        private List<SuperBonus> _db = new List<SuperBonus> ();

        public async Task<Result> InsertSuperBonusBase (Guid id, decimal amount) {
            _db.Add (new SuperBonus (id, amount, SuperBonusStatuses.Pending));
            return await Task.FromResult (new Result ());
        }

        public async Task<Result> UpdateSuperBonusBase (Guid id, decimal amount) {
            var bonus = _db.FirstOrDefault (d => d.ID == id);
            if (bonus != null)
                bonus.BaseAmount = amount;
            return await Task.FromResult (new Result ());
        }

        public async Task<SuperBonus> GetPending () {
            return await Task
                .FromResult (_db.FirstOrDefault (d => d.Status == SuperBonusStatuses.Pending));
        }

        public async Task<Result> UpdateStatus (Guid id, SuperBonusStatuses status) {
            var bonus = _db.FirstOrDefault (d => d.ID == id);
            if (bonus != null)
                bonus.Status = status;
            return await Task.FromResult (new Result ());
        }

        public async Task<SuperBonus> GetActive() {
             return await Task
                .FromResult (_db.FirstOrDefault (d => d.Status == SuperBonusStatuses.Active));
        }
    }
}