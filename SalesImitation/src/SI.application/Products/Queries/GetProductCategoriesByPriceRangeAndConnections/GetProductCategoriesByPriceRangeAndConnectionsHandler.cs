using MediatR;
using SI.Common.Models;
using SI.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using SI.Domain.Abstractions.Repositories;
using System.Collections.Generic;

namespace SI.Application.Products {
    public class GetProductCategoriesByPriceRangeAndConnectionsHandler : IRequestHandler<GetProductCategoriesByPriceRangeAndConnectionsRequest, IEnumerable<ProductCategory>> {

        IProductRepository _productRepository;

        public GetProductCategoriesByPriceRangeAndConnectionsHandler(IProductRepository productRepository){
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductCategory>> Handle(GetProductCategoriesByPriceRangeAndConnectionsRequest request, CancellationToken token){
           return await _productRepository.GetProductCategoriesWithConnectedProducts(request.From, request.To, 1);
        }
    }
}