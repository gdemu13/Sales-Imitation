using MediatR;
using SI.Common.Models;
using SI.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using SI.Domain.Abstractions.Repositories;
using System.Collections.Generic;

namespace SI.Application.Products {
    public class GetProductCategoriesByPriceRangehandler : IRequestHandler<GetProductCategoriesByPriceRangeRequest, IEnumerable<ProductCategory>> {

        IProductRepository _productRepository;

        public GetProductCategoriesByPriceRangehandler(IProductRepository productRepository){
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductCategory>> Handle(GetProductCategoriesByPriceRangeRequest request, CancellationToken token){
           return await _productRepository.GetProductCategories(request.From, request.To);
        }
    }
}