using MediatR;
using SI.Common.Models;
using System;

namespace SI.Application.Categories {
    public class ChangeCategoryNameRequest : IRequest<Result> {
        public Guid ID {get; set;}
        public string Name {get; set;}
    }
}