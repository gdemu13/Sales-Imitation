using MediatR;
using SI.Common.Models;
using System;

namespace SI.Application.Categories  {
    public class SaveNewCategoryRequest : IRequest<Result> {
        public string Name {get; set;}
        public string Color { get; set; }
        public string IconUrl { get; set; }
        public bool IsActive { get; set; }
    }
}