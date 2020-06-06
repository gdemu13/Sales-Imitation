using System;
using SI.Domain.Abstractions.DomainEvents;

namespace SI.Domain.Abstractions{
    public class CurrentMissionCreated : IDomainEvent{
        public CurrentMissionCreated(Guid playerID, DateTime deadline, string desc,
                                string product1, string product2, string code)
        {
            PlayerID = playerID;
            Deadline = deadline;
            Desc = desc;
            Product1 = product1;
            Product2 = product2;
            Code = code;
        }

        public Guid PlayerID { get; }
        public DateTime Deadline { get; }
        public string Desc { get; }
        public string Product1 { get; }
        public string Product2 { get; }
        public string Code { get; }
    }
}