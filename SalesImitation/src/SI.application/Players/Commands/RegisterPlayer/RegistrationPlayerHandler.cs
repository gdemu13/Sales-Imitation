using System;
using System.Threading.Tasks;
using MediatR;
using SI.Common.Models;
using System.Threading;
using SI.Domain.Entities;
using SI.Domain.Abstractions.Repositories;

namespace SI.Application.Players {
    public class RegistrationPlayerHandler : IRequestHandler<RegisterPlayerRequest, Result> {
        private IPlayerRepository _playerRepository;

        public RegistrationPlayerHandler(IPlayerRepository playerRepository){
            _playerRepository = playerRepository;
        }

        public async Task<Result> Handle (RegisterPlayerRequest request, CancellationToken token) {
            var player = new Player(Guid.NewGuid(), request.Username, request.Password, request.Mail, request.Firstname, request.Lastname, 1, (PlayerAvatars)request.AvatarID, request.Phone);
            player.FacebookID = request.FacebookID;
            return await _playerRepository.InsertPlayerIfUnique(player);
        }
    }
}