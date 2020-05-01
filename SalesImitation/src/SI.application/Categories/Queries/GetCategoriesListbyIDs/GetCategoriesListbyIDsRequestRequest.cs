using MediatR;
using SI.Common.Models;
using System;
using System.Collections.Generic;
using SI.Domain.Entities;
using System.Collections;

namespace SI.Application.Categories  {
    public class GetCategoriesListbyIDsRequest : IRequest<IEnumerable<GetCategoriesListbyIDsResponse>> {
        public GetCategoriesListbyIDsRequest(IEnumerable<Guid> ids)
        {
            IDs = ids;
        }

        public IEnumerable<Guid> IDs { get; }
    }
}