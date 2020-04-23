using MediatR;
using SI.Common.Models;
using SI.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using SI.Domain.Abstractions.Repositories;
using System.Collections.Generic;

namespace SI.Application.Products {
    public class GetRangeOfProductsHandler : IRequestHandler<GetRangeOfProductsRequest, IEnumerable<Product>> {

        IProductRepository _productRepository;

        public GetRangeOfProductsHandler(IProductRepository productRepository){
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetRangeOfProductsRequest request, CancellationToken token){
           return await _productRepository.GetRange(request.Skip, request.Take);
        }
    }
}