using System;

namespace SI.Domain.Entities {
    public class Mission : BaseEntity {
        public Mission (Guid id, string name, string description, int level, MissionMoneyRange range) {
            ID = id;
            Name = name;
            Description = description;
            PriceRange = range;
            Level = level;
        }

        public Mission (Guid id, string name, string description, int level, decimal priceFrom, decimal priceTo) {
            ID = id;
            Name = name;
            Description = description;
            PriceRange = new MissionMoneyRange (priceFrom, priceTo);
            Level = level;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public MissionMoneyRange PriceRange { get; set; }
        public int Level { get; set; }
    }
}