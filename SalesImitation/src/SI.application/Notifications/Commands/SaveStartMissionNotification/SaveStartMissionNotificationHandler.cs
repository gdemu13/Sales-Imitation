using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;
using SI.Domin.Abstractions.Authentication;

namespace SI.Application.Notifications
{
    public class SaveStartMissionNotificationHandler : IRequestHandler<SaveStartMissionNotificationRequest, Result>
    {
        private readonly INotificationRepository repository;

        public SaveStartMissionNotificationHandler(INotificationRepository repository)
        {
            this.repository = repository;
        }
        public Task<Result> Handle(Notifications.SaveStartMissionNotificationRequest req, CancellationToken cancellationToken)
        {
            var notification = new Notification(Guid.NewGuid(),
                                                req.PlayerID,
                                                req.Title,
                                                req.Description,
                                                req.Type,
                                                 req.Deadline,
                                                 false);
            return repository.Insert(notification);
        }
    }
}