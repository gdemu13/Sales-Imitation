using MediatR;
using SI.Common.Models;
using System;
using System.Collections.Generic;
using SI.Domain.Entities;

namespace SI.Application.Categories  {
    public class GetCategoryRequest : IRequest<Category> {
        public Guid ID {get; set;}

        public GetCategoryRequest(Guid id) {
            ID = id;
        }
    }
}