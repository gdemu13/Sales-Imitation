using System;
using System.Threading.Tasks;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;

namespace SI.Domain.Services
{
    public interface IPlayerService
    {
        Task<Result> BuyExtraTime(Guid playerID, int hours);
    }
}