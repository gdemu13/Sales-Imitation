using MediatR;
using SI.Common.Models;
using System;
using System.Collections.Generic;
using SI.Domain.Entities;

namespace SI.Application.Products  {
    public class GetProductRequest : IRequest<Product> {
        public Guid ID {get; set;}
        public GetProductRequest(Guid id) {
            ID = id;
        }
    }
}