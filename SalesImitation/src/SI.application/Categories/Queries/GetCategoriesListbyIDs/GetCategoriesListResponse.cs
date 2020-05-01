using MediatR;
using SI.Common.Models;
using System;
using System.Collections.Generic;
using SI.Domain.Entities;
using System.Collections;

namespace SI.Application.Categories
{
    public class GetCategoriesListbyIDsResponse : IRequest<IEnumerable<Category>>
    {

        public Guid ID { get; set; }
        public string Name { get; set; }
    }
}