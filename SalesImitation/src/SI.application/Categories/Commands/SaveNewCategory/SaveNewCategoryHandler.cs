using MediatR;
using SI.Common.Models;
using SI.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using SI.Domain.Abstractions.Repositories;
using System;

namespace SI.Application.Categories {
    public class SaveNewCategoryHandler : IRequestHandler<SaveNewCategoryRequest, Result> {

        ICategoryRepository _categoryRepository;

        public SaveNewCategoryHandler(ICategoryRepository categoryRepository){
            _categoryRepository = categoryRepository;
        }

        public async Task<Result> Handle(SaveNewCategoryRequest request, CancellationToken token){
            var newID = Guid.NewGuid();
           var category = new Category(newID, request.Name, request.Color, request.IconUrl);
           category.IsActive = true;
           return await _categoryRepository.Insert(category);
        }
    }
}