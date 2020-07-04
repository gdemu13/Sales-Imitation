using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Application.EventHandlers;
using SI.Application.Notifications;
using SI.Application.Players;
using SI.Domain.Abstractions;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;

namespace SI.Application.Events
{
    public class AddPlayerCoinsOnSoldProduct : INotificationHandler<DomainEvent<CurrentMissionSoldProduct>>
    {
        private readonly IMediator mediator;

        public AddPlayerCoinsOnSoldProduct(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task Handle(DomainEvent<CurrentMissionSoldProduct> n, CancellationToken cancellationToken)
        {
            await mediator.Send(new AddCoinsToPlayerRequest
            {
                PlayerID = n.Instanse.PlayerID,
                Reason = "პროდუქტის გაყიდვა",
                Coins = n.Instanse.Amount
            });
        }
    }
}