using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;

namespace SI.Application.Notifications
{
    public class GetNewNotificationsHandler : IRequestHandler<GetNewNotificationsRequest, Notification>
    {
        private readonly INotificationRepository repository;

        public GetNewNotificationsHandler(INotificationRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Notification> Handle(GetNewNotificationsRequest request, CancellationToken cancellationToken)
        {
            var notifications = await repository.GetUnseenByPlayer(request.PlayerID);
            if(notifications != null && notifications.Count() > 0)
                await repository.SetSeen(new List<Guid>(){notifications.First().ID});
            return notifications?.FirstOrDefault();
        }
    }
}