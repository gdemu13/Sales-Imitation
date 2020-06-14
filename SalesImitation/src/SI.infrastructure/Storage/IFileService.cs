using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SI.Common.Models;

namespace SI.Infrastructure.Storage
{
    public interface IFIleService
    {
        Task<Result<string>> SaveFile(IFormFile file);
        Task<byte[]> GetFile(string fileName);
        Task<Result<string>> SavePersonalFile(IFormFile file, Guid userID);
        Task<byte[]> GetPersonalFile(string fileName);
    }
}