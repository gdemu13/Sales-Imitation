using MediatR;
using SI.Common.Models;
using SI.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using SI.Domain.Abstractions.Repositories;

namespace SI.Application.Categories {
    public class SetIsActiveToCategoryHandler : IRequestHandler<SetIsActiveToCategoryRequest, Result> {

        ICategoryRepository _categoryRepository;

        public SetIsActiveToCategoryHandler(ICategoryRepository categoryRepository){
            _categoryRepository = categoryRepository;
        }

        public async Task<Result> Handle(SetIsActiveToCategoryRequest request, CancellationToken token){
           return await _categoryRepository.SetIsActive(request.ID, request.IsActive);
        }
    }
}