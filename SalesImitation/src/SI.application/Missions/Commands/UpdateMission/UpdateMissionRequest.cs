using System;
using MediatR;
using SI.Common.Models;

namespace SI.Application.Missions
{
    public class UpdateMissionRequest : IRequest<Result>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationInHours { get; set; }
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }
    }
}