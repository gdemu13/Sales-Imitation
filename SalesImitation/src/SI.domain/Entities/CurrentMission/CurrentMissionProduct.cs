using System;

namespace SI.Domain.Entities
{
    public class CurrentMissionProduct : BaseEntity
    {
        public CurrentMissionProduct(Guid id, decimal price, string name, string description, string partnerName, Guid partnerID, string imageUrl,
                                    string partnetaAddress, string gift, decimal expectedCoin) {
            ID = id;
            Price = price;
            Name = name;
            Description = description;
            PartnerName = partnerName;
            PartnerID = partnerID;
            ImageUrl = imageUrl;
            PartnetaAddress = partnetaAddress;
            Gift = gift;
            ExpectedCoin = expectedCoin;
        }

        public decimal Price { get; set; }
        public string Name { get; }
        public string Description { get; }
        public string ImageUrl { get; set; }
        public string PartnerName { get; }
        public Guid PartnerID { get; }
        public string PartnetaAddress { get; }
        public string Gift { get; }
        public decimal ExpectedCoin { get; }
    }
}