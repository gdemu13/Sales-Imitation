using MediatR;
using SI.Common.Models;
using SI.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using SI.Domain.Abstractions.Repositories;
using System.Collections.Generic;

namespace SI.Application.Categories {
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesRequest, IEnumerable<Category>> {

        ICategoryRepository _categoryRepository;

        public GetAllCategoriesHandler(ICategoryRepository categoryRepository){
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> Handle(GetAllCategoriesRequest request, CancellationToken token){
           return await _categoryRepository.GetAll();
        }
    }
}