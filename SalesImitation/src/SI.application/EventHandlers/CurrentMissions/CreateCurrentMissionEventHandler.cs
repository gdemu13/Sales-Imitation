using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Application.EventHandlers;
using SI.Application.Notifications;
using SI.Domain.Abstractions;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;

namespace SI.Application.Events
{
    public class CreateCurrentMissionEventHandler : INotificationHandler<DomainEvent<CurrentMissionCreated>>
    {
        private readonly IMediator mediator;
        private readonly INotificationRepository repository;

        public CreateCurrentMissionEventHandler(IMediator mediator, INotificationRepository repository)
        {
            this.mediator = mediator;
            this.repository = repository;
        }
        public async Task Handle(DomainEvent<CurrentMissionCreated> notification, CancellationToken cancellationToken)
        {
            var e = notification.Instanse;
            await mediator.Send(new SaveStartMissionNotificationRequest(
                 e.PlayerID,
                 "შეტყობინება",
                 e.Desc,
                 NotificationTypes.SUCCESS,
                 e.Deadline,
                 false
             ));

            // var not = new Notification(
            //    Guid.NewGuid(),
            //     e.PlayerID,
            //    "შეტყობინება",
            //    e.Desc,
            //    NotificationTypes.SUCCESS,
            //    e.Deadline,
            //    false);
            // await repository.Insert(not);
        }
    }
}