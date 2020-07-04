using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;

namespace SI.Application.Players {
    public class AddCoinsToPlayerHandler : IRequestHandler<AddCoinsToPlayerRequest, Result>
    {
        private readonly IPlayerRepository repository;

        public AddCoinsToPlayerHandler(IPlayerRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Result> Handle(AddCoinsToPlayerRequest request, CancellationToken cancellationToken)
        {
            var player = await repository.GetByID(request.PlayerID);
            player.Item1.DepositCoins(request.Coins, request.Reason);
            return await repository.UpdatePlayer(player.Item1, player.Item2.Value);
        }
    }
}