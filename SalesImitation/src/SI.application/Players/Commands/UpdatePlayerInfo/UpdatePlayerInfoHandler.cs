using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;

namespace SI.Application.Players
{
    public class UpdatePlayerInfoHandler : IRequestHandler<UpdatePlayerInfoRequest, Result>
    {
        private readonly IPlayerRepository repository;

        public UpdatePlayerInfoHandler(IPlayerRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Result> Handle(UpdatePlayerInfoRequest request, CancellationToken cancellationToken)
        {
            var playerAndDate = await repository.GetByID(request.ID);
            var player = playerAndDate.Item1;
            player.Firstname = request.Firstname;
            player.Lastname = request.Lastname;
            player.Avatar = request.Avatar;
            player.Mail = request.Mail;
            player.Phone = request.Phone;
            return await repository.UpdatePlayer(player, playerAndDate.Item2.Value);
        }
    }
}