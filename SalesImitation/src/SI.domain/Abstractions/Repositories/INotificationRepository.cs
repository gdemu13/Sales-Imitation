using SI.Common.Models;
using System.Threading.Tasks;
using SI.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SI.Domain.Abstractions.Repositories
{

    public interface INotificationRepository
    {
        Task<Notification> Get(Guid ID);
        Task<IEnumerable<Notification>> GetRange(int skip, int take, string searchWord);
        Task<IEnumerable<Notification>> Count(string searchWord);
        Task<IEnumerable<Notification>> GetUnseenByPlayer(Guid playerID);
        Task<Result> Insert(Notification category);
        Task<Result> Update(Guid id, Notification category);
        Task<Result> SetSeen(List<Guid> ids);
    }
}