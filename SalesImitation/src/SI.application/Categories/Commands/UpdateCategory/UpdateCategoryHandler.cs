using MediatR;
using SI.Common.Models;
using System.Threading;
using System.Threading.Tasks;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;

namespace SI.Application.Categories {
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryRequest, Result> {

        ICategoryRepository _categoryRepository;

        public UpdateCategoryHandler(ICategoryRepository categoryRepository){
            _categoryRepository = categoryRepository;
        }

        public async Task<Result> Handle(UpdateCategoryRequest request, CancellationToken token){
           var category = new Category(request.ID,request.Name, request.Color, request.IconUrl);
           return await _categoryRepository.Update(request.ID, category);
        }
    }
}