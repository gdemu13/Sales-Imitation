using System;
using SI.Domain.Abstractions.DomainEvents;

namespace SI.Domain.Abstractions{
    public class CurrentMissionSoldProduct : IDomainEvent{
        public CurrentMissionSoldProduct(Guid playerID, Guid partnerID, Guid partnerUserID, Guid productID, decimal amount)
        {
            PlayerID = playerID;
            PartnerID = partnerID;
            PartnerUserID = partnerUserID;
            ProductID = productID;
            Amount = amount;
        }

        public Guid PlayerID { get; }
        public Guid PartnerID { get; }
        public Guid PartnerUserID { get; }
        public Guid ProductID { get; }
        public decimal Amount { get; }
    }
}