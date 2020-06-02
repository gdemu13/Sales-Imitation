using System;

namespace SI.Domain.Entities
{
    public class CurrentMissionProduct : BaseEntity
    {
        public CurrentMissionProduct(Guid id, string name, string description, string partnerName, string imageUrl,
                                    string partnetaAddress, string gift, decimal expectedCoin) {
            ID = id;
            Name = name;
            Description = description;
            PartnerName = partnerName;
            ImageUrl = imageUrl;
            PartnetaAddress = partnetaAddress;
            Gift = gift;
            ExpectedCoin = expectedCoin;
        }

        public string Name { get; }
        public string Description { get; }
        public string ImageUrl { get; set; }
        public string PartnerName { get; }
        public string PartnetaAddress { get; }
        public string Gift { get; }
        public decimal ExpectedCoin { get; }
    }
}