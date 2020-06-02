using MediatR;
using SI.Common.Models;
using SI.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using SI.Domain.Abstractions.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SI.Application.Categories
{
    public class GetCategoriesListbyIDsRequestHandler : IRequestHandler<GetCategoriesListbyIDsRequest, IEnumerable<GetCategoriesListbyIDsResponse>>
    {

        ICategoryRepository _categoryRepository;

        public GetCategoriesListbyIDsRequestHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<GetCategoriesListbyIDsResponse>> Handle(GetCategoriesListbyIDsRequest request, CancellationToken token)
        {
            var categories = await _categoryRepository.GetByIDs(request.IDs);
            return categories.Select(c => new GetCategoriesListbyIDsResponse
            {
                ID = c.ID,
                Name = c.Name,
                Color = c.Color,
                IconUrl = c.IconUrl
            });
        }
    }
}