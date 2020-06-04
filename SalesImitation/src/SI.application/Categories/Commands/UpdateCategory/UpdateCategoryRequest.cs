using MediatR;
using SI.Common.Models;
using System;

namespace SI.Application.Categories
{
    public class UpdateCategoryRequest : IRequest<Result>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string IconUrl { get; set; }
        public bool IsActive { get; set; }
    }
}