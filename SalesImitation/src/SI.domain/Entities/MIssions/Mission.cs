namespace SI.Domain.Entities {
    public class Mission : BaseEntity {
        public Mission (string name, string description, int Round, MissionMoneyRange range, MissionStatuses status) {
            Name = name;
            Description = description;
            PriceRange = range;
            Round = Round;
            Status = status;
        }

        public Mission (string name, string description, int Round, decimal priceFrom, decimal priceTo, MissionStatuses status) {
            Name = name;
            Description = description;
            PriceRange = new MissionMoneyRange (priceFrom, priceTo);
            Round = Round;
            Status = status;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public MissionMoneyRange PriceRange { get; set; }
        public int Round { get; set; }
        public MissionStatuses Status { get; set; }
    }
}