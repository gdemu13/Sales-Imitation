using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SI.Common.Models;

namespace SI.Infrastructure.Storage
{
    public interface IFIleService
    {
        Task<Result<string>> SaveFile(IFormFile file);
        Task<byte[]> GetFile(string fileName);
    }
}