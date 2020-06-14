using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;

namespace SI.Application.Players
{
    public class ChangePasswordHandler : IRequestHandler<ChangePasswordRequest, Result>
    {
        private readonly IPlayerRepository repository;

        public ChangePasswordHandler(IPlayerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            var PlayerAndDate = await repository.GetByID(request.PlayerID);
            var player = PlayerAndDate.Item1;
            var res = player.ChangePassword(request.CurrentPassword, request.NewPassword);
            if (res.IsSuccess)
                return await repository.UpdatePlayer(player, PlayerAndDate.Item2.Value);
            else return res;
        }
    }
}