using MediatR;
using SI.Common.Models;
using System.Threading;
using System.Threading.Tasks;
using SI.Domain.Abstractions.Repositories;

namespace SI.Application.Categories {
    public class ChangeCategoryNameHandler : IRequestHandler<ChangeCategoryNameRequest, Result> {

        ICategoryRepository _categoryRepository;

        public ChangeCategoryNameHandler(ICategoryRepository categoryRepository){
            _categoryRepository = categoryRepository;
        }

        public async Task<Result> Handle(ChangeCategoryNameRequest request, CancellationToken token){
           return await _categoryRepository.UpdateName(request.ID, request.Name);
        }
    }
}