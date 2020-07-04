using SI.Common.Models;
using System.Threading.Tasks;
using SI.Domain.Entities;
using System;

namespace SI.Domain.Abstractions.Repositories {

    public interface ISuperBonusRepository {
        Task<Result> InsertSuperBonusBase(SuperBonus bonus);
        Task<Result> UpdateSuperBonusBase (Guid id, decimal amount);
        Task<SuperBonus> GetPending();
        Task<Result> UpdateStatus (Guid id, SuperBonusStatuses status);
        Task<SuperBonus> GetActive();
        Task<Result> IncreaseBonus(decimal amount, string source);
    }
}