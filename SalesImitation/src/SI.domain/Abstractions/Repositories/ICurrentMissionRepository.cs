using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SI.Common.Models;
using SI.Domain.Entities;

namespace SI.Domain.Abstractions.Repositories {

    public interface ICurrentMissionRepository : IRepository<ICurrentMissionRepository> {
        Task<CurrentMission> Get (Guid ID);
        Task<IEnumerable<CurrentMission>> GetRange (int skip, int take);
        Task<Result> Insert (CurrentMission mission);
        Task<Result> UpdateIfNotChanged (Guid id, CurrentMission mission, DateTime checkDate);
        Task<(CurrentMission, DateTime?)> GetActiveByUser(Guid ID);
        Task<CurrentMission> GetByUser(Guid id);
    }
}