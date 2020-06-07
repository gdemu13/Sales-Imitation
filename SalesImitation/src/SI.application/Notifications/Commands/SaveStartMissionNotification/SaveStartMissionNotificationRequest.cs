using System;
using MediatR;
using SI.Common.Models;
using SI.Domain.Entities;

namespace SI.Application.Notifications {
    public class SaveStartMissionNotificationRequest : IRequest<Result> {
         public SaveStartMissionNotificationRequest(Guid playerID, string title, string description, NotificationTypes type, DateTime? deadline, bool seen)
        {
            PlayerID = playerID;
            Title = title;
            Description = description;
            Type = type;
            Deadline = deadline;
        }

        public Guid PlayerID { get; }
        public string Title { get; }
        public string Description { get; }
        public NotificationTypes Type { get; }
        public DateTime? Deadline { get; }
    }
}