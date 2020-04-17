using MediatR;
using SI.Common.Models;
using System;
using System.Collections.Generic;
using SI.Domain.Entities;

namespace SI.Application.Categories  {
    public class GetAllCategoriesRequest : IRequest<IEnumerable<Category>> {
    }
}