using System;

namespace SI.Domain.Entities
{
    public class Notification : BaseEntity
    {
        public Notification(Guid id, Guid playerID, string title, string description, NotificationTypes type, DateTime? deadline, bool seen)
        {
            ID = id;
            PlayerID = playerID;
            Title = title;
            Description = description;
            Type = type;
            Deadline = deadline;
            Seen = seen;
        }

        public Guid PlayerID { get; }
        public string Title { get; }
        public string Description { get; }
        public NotificationTypes Type { get; }
        public DateTime? Deadline { get; }
        public bool Seen { get; }
    }
}