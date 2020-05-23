using MediatR;
using SI.Common.Models;
using System;
using System.Collections.Generic;
using SI.Domain.Entities;

namespace SI.Application.Products
{
    public class GetProductCategoriesByPriceRangeAndConnectionsRequest : IRequest<IEnumerable<ProductCategory>>
    {
        public GetProductCategoriesByPriceRangeAndConnectionsRequest(decimal from, decimal to)
        {
            From = from;
            To = to;
        }

        public GetProductCategoriesByPriceRangeAndConnectionsRequest()
        {

        }

        public decimal From { get; set; }
        public decimal To { get; set; }
    }
}