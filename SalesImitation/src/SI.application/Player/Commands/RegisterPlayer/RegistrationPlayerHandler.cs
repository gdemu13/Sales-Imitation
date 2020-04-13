using System;
using System.Threading.Tasks;
using MediatR;
using SI.Common.Models;
using System.Threading;
using SI.Domain.Entities;
using SI.Domain.Abstractions.Repositories;

namespace SI.Application.Player {
    public class RegistrationPlayerHandler : IRequestHandler<RegisterPlayerRequest, Result> {
        private IPlayerRepository _playerRepository;

        public RegistrationPlayerHandler(IPlayerRepository playerRepository){
            _playerRepository = playerRepository;
        }

        public async Task<Result> Handle (RegisterPlayerRequest request, CancellationToken token) {
            var player = new SI.Domain.Entities.Player();
            return await _playerRepository.SavePlayer(player);
        }
    }
}