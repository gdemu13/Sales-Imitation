using MediatR;
using SI.Common.Models;
using SI.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using SI.Domain.Abstractions.Repositories;
using System.Collections.Generic;

namespace SI.Application.Products {
    public class GetRangeOfProductsHandler : IRequestHandler<GetRangeOfProductsRequest, GetRangeOfProductResponse> {

        IProductRepository _productRepository;

        public GetRangeOfProductsHandler(IProductRepository productRepository){
            _productRepository = productRepository;
        }

        public async Task<GetRangeOfProductResponse> Handle(GetRangeOfProductsRequest request, CancellationToken token){
            var items = await _productRepository.GetRange(request.Skip, request.Take, request.SearchWord);
            int quantity = await _productRepository.Count(request.SearchWord);
            return new GetRangeOfProductResponse
            {
                Items = items,
                Quantity = quantity
            };
        }
    }
}