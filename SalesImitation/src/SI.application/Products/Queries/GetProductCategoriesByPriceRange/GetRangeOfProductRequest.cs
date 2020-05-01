using MediatR;
using SI.Common.Models;
using System;
using System.Collections.Generic;
using SI.Domain.Entities;

namespace SI.Application.Products
{
    public class GetProductCategoriesByPriceRangeRequest : IRequest<IEnumerable<ProductCategory>>
    {
        public GetProductCategoriesByPriceRangeRequest(decimal from, decimal to)
        {
            From = from;
            To = to;
        }

        public GetProductCategoriesByPriceRangeRequest()
        {

        }

        public decimal From { get; set; }
        public decimal To { get; set; }
    }
}