using System.Threading.Tasks;
using SI.Common.Models;

namespace SI.Application.Contents
{
    public interface IContentRepository
    {
        Task<ContentModel> Get(string name);
        Task<Result> Save(ContentModel content);
    }
}