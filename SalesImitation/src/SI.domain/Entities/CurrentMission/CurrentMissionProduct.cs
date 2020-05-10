using System;

namespace SI.Domain.Entities
{
    public class CurrentMissionProduct : BaseEntity
    {
        public CurrentMissionProduct(Guid id, string name, string description, string partnerName,
                                    string partnetaAddress, string benefits, decimal expectedCoin) {
            ID = id;
            Name = name;
            Description = description;
            PartnerName = partnerName;
            PartnetaAddress = partnetaAddress;
            Benefits = benefits;
            ExpectedCoin = expectedCoin;
        }

        public string Name { get; }
        public string Description { get; }
        public string PartnerName { get; }
        public string PartnetaAddress { get; }
        public string Benefits { get; }
        public decimal ExpectedCoin { get; }
    }
}