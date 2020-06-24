using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SI.Common.Models;
using SI.Domain.Entities;

namespace SI.Domain.Abstractions.Repositories
{
    public interface IPartnerUserRepository
    {
        Task<PartnerUser> Get(Guid id);
        Task<IEnumerable<PartnerUser>> GetByPartner(Guid partnerID);
        Task<PartnerUser> GetByUsername(string username);
        Task<Result> Insert(PartnerUser partnerUser);
        Task<Result> Update(Guid id, PartnerUser partnerUser);
    }
}