using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Application.EventHandlers;
using SI.Domain.Abstractions;

namespace SI.Application.Events
{
    public class CreateCurrentMissionEventHandler : INotificationHandler<DomainEvent<CurrentMissionCreated>>
    {
        public async Task Handle(DomainEvent<CurrentMissionCreated> notification, CancellationToken cancellationToken)
        {
            var pl = notification.Instanse.PlayerID;
        }
    }
}