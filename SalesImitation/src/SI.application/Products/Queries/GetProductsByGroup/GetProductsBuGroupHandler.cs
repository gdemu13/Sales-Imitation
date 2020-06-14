using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;

namespace SI.Application.Products
{
    public class GetProductsBuGroupHandler : IRequestHandler<GetProductsBuGroupRequest, IEnumerable<Product>>
    {
        private readonly IProductRepository repo;

        public GetProductsBuGroupHandler(IProductRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsBuGroupRequest request, CancellationToken cancellationToken)
        {
            return await repo.GetByGroup(request.GroupID);
        }
    }
}