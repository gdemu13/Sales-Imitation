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
    public class GetNewNotificationsHandler : IRequestHandler<GetNewNotificationsRequest, IEnumerable<Notification>>
    {
        private readonly INotificationRepository repository;

        public GetNewNotificationsHandler(INotificationRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Notification>> Handle(GetNewNotificationsRequest request, CancellationToken cancellationToken)
        {
            var notifications = await repository.GetUnseenByPlayer(request.PlayerID);
            await repository.SetSeen(notifications.Select(s => s.ID));
            return notifications;
        }
    }
}