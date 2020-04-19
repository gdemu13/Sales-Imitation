using System;
using MediatR;
using SI.Common.Models;

namespace SI.Application.Products {
    public class SetIsActiveToProductRequest : IRequest<Result> {
        public Guid ID { get; set; }
        public bool IsActive {get; set;}
    }
}
