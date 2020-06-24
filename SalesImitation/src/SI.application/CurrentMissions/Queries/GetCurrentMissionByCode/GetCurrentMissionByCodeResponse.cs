using System;

namespace SI.Application.CurrentMissions
{
    public class GetCurrentMissionByCodeResponse
    {
        public GetCurrentMissionByCodeResponseProduct Product1 { get; set; }
        public GetCurrentMissionByCodeResponseProduct Product2 { get; set; }
    }

    public class GetCurrentMissionByCodeResponseProduct
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}