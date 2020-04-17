using SI.Common.Models;
using System.Threading.Tasks;
using SI.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SI.Domain.Abstractions.Repositories {

    public interface IproductRepository {
        Task<IEnumerable<Product>> GetRange(int skip = 0, int take = 0);
        Task<Result> Save (Product category);
        Task<Result> Update (Guid id, Product category);
        Task<Result> SetIsActive (Guid id, bool isActive);
    }
}