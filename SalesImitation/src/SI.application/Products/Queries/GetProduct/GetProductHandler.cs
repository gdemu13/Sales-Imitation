using MediatR;
using SI.Common.Models;
using SI.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using SI.Domain.Abstractions.Repositories;
using System.Collections.Generic;
using System;

namespace SI.Application.Products {
    public class GetProductHandler : IRequestHandler<GetProductRequest, Product> {

        IProductRepository _productRepository;

        public GetProductHandler(IProductRepository productRepository){
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(GetProductRequest request, CancellationToken token){
           return await _productRepository.Get(request.ID);
        }
    }
}