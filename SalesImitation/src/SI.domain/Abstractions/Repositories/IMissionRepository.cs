using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SI.Common.Models;
using SI.Domain.Entities;

namespace SI.Domain.Abstractions.Repositories {

    public interface IMissionRepository {
        Task<Mission> Get (Guid ID);
        Task<IEnumerable<Mission>> GetAll ();
        Task<Result> InsertIfLast (Mission mission, DateTime checkDate);
        Task<Result> Update (Guid id, Mission mission, DateTime checkDate);
        Task<DateTime> GetLastUpdateDate ();
        Task<int> GetLastLevelNumber ();
        Task<IEnumerable<Mission>> GetByPriceRange (decimal from, decimal to);
    }
}