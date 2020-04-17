using MediatR;
using SI.Common.Models;
using System;

namespace SI.Application.Categories  {
    public class SetIsActiveToCategoryRequest : IRequest<Result> {
        public Guid ID {get; set;}
        public bool IsActive {get; set;}
    }
}