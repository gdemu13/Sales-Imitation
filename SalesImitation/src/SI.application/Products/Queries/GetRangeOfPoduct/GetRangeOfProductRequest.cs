using MediatR;
using SI.Common.Models;
using System;
using System.Collections.Generic;
using SI.Domain.Entities;

namespace SI.Application.Products  {
    public class GetRangeOfProductsRequest : IRequest<IEnumerable<Product>> {
        public int Skip {get; set;}
        public int Take {get; set;} = 10;
    }
}