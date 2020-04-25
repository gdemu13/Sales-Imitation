
using System;
using SI.Common.Models;
using SI.Domain.Entities;
using System.Threading.Tasks;

namespace SI.Domain.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByID(Guid ID);

        Task<User> GetByUserName(string username);

        Task<Result> Insert(User user);

        Task<Result> UpdatePassword(Guid ID, string newPasswordHash, DateTime checkDate);
    }
}