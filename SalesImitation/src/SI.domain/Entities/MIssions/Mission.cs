using System;

namespace SI.Domain.Entities {
    public class Mission : BaseEntity {
        public Mission (Guid id, string name, string description, int Round, MissionMoneyRange range) {
            ID = id;
            Name = name;
            Description = description;
            PriceRange = range;
            Round = Round;
        }

        public Mission (Guid id, string name, string description, int Round, decimal priceFrom, decimal priceTo) {
            ID = id;
            Name = name;
            Description = description;
            PriceRange = new MissionMoneyRange (priceFrom, priceTo);
            Round = Round;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public MissionMoneyRange PriceRange { get; set; }
        public int Round { get; set; }
    }
}