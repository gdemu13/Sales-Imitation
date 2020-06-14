using System;
using System.Collections.Generic;
using MediatR;
using SI.Domain.Entities;

namespace SI.Application.Products {
    public class GetProductsBuGroupRequest : IRequest<IEnumerable<Product>> {
        public Guid GroupID { get; set; }
    }
}