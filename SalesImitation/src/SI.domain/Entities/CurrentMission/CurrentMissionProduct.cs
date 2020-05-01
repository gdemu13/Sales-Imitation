namespace SI.Domain.Entities
{
    public class CurrentMissionProduct
    {
        public CurrentMissionProduct(string name, string description, string partnerName,
                                    string partnetaAddress, string benefits, int expectedCoin) {
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
        public int ExpectedCoin { get; }
    }
}