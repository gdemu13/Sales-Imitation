using System;
using SI.Domain.Abstractions.DomainEvents;

namespace SI.Domain.Events {
    public class PlayerStartNewMissionEvent : IDomainEvent {
        public Guid PlayerID { get; set; }
        public string UserName { get; set; }
        public string MissionName { get; set; }
    }
}