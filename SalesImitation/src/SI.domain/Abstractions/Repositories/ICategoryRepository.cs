using SI.Common.Models;
using System.Threading.Tasks;
using SI.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SI.Domain.Abstractions.Repositories {

    public interface ICategoryRepository {
        Task<Category> Get(Guid ID);
        Task<IEnumerable<Category>> GetAll();
        Task<IEnumerable<Category>> GetByIDs(IEnumerable<Guid> ids);
        Task<Result> Insert (Category category);
        Task<Result> UpdateName (Guid id, string name);
        Task<Result> SetIsActive (Guid id, bool isActive);
    }
}