using MediatR;
using SI.Common.Models;
using SI.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using SI.Domain.Abstractions.Repositories;
using System.Collections.Generic;

namespace SI.Application.Categories {
    public class GetCategoryHandler : IRequestHandler<GetCategoryRequest, Category> {

        ICategoryRepository _categoryRepository;

        public GetCategoryHandler(ICategoryRepository categoryRepository){
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Handle(GetCategoryRequest request, CancellationToken token){
           return await _categoryRepository.Get(request.ID);
        }
    }
}