using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SI.Common.Models;

namespace SI.Application.FAQs
{
    public interface IFAQsRepository
    {
        Task<IEnumerable<FAQModel>> GetAll();
        Task<Result> Save(FAQModel content);
        Task<Result> Remove(Guid id);
    }
}