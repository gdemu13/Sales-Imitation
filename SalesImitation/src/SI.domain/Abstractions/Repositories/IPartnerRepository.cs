using SI.Common.Models;
using System.Threading.Tasks;
using SI.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SI.Domain.Abstractions.Repositories {

    public interface IPartnerRepository {
        Task<Partner> Get(Guid ID);
        Task<IEnumerable<Partner>> GetRange(int skip = 0, int take = 0);
        Task<Result> Insert (Partner Partner);
        Task<Result> Update (Guid id, Partner Partner);
        Task<Result> SetIsActive (Guid id, bool isActive);
    }
}