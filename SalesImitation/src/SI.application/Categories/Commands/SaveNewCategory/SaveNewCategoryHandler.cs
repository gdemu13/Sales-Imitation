using MediatR;
using SI.Common.Models;
using SI.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using SI.Domain.Abstractions.Repositories;

namespace SI.Application.Categories {
    public class SaveNewCategoryHandler : IRequestHandler<SaveNewCategoryRequest, Result> {

        ICategoryRepository _categoryRepository;

        public SaveNewCategoryHandler(ICategoryRepository categoryRepository){
            _categoryRepository = categoryRepository;
        }

        public async Task<Result> Handle(SaveNewCategoryRequest request, CancellationToken token){
           var category = new Category(request.ID, request.Name);
           return await _categoryRepository.Insert(category);
        }
    }
}