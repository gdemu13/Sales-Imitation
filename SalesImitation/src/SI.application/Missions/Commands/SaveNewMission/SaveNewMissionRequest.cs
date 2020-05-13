using System;
using MediatR;
using SI.Common.Models;

namespace SI.Application.Missions {
    public class SaveNewMissionRequest : IRequest<Result> {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }
    }
}