using SI.Common.Models;
using System.Threading.Tasks;
using SI.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SI.Domain.Abstractions.Repositories
{

    public interface IProductRepository
    {
        Task<Product> Get(Guid ID);
        Task<IEnumerable<Product>> GetRange(int skip = 0, int take = 0);
        Task<Result> Insert(Product category);
        Task<Result> Update(Guid id, Product category);
        Task<Result> SetIsActive(Guid id, bool isActive);

        Task<IEnumerable<ProductCategory>> GetProductCategories(decimal fromPrice, decimal toPrice);

        Task<IEnumerable<ProductCategory>> GetProductCategoriesWithConnectedProducts(decimal fromPrice, decimal toPrice, int minConnections);
        Task<IEnumerable<Product>> GetByGroup(Guid groupID);
        Task<IEnumerable<Product>> GetByCategoryAndPriceRange(Guid categoryID, decimal from, decimal to);
    }
}