using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;

namespace SI.Application.Products {
    public class SetIsActiveToProductHandler : IRequestHandler<SetIsActiveToProductRequest, Result> {

        IProductRepository _productRepository;

        public SetIsActiveToProductHandler (IProductRepository productRepository) {
            _productRepository = productRepository;
        }

        public async Task<Result> Handle (SetIsActiveToProductRequest req, CancellationToken token) {
            return await _productRepository.SetIsActive (req.ID, req.IsActive);
        }
    }
}