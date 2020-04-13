using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;

namespace SI.Application.Player {
    public class GetLeaderboardHandler : IRequestHandler<GetLeaderboardRequest, IEnumerable<SI.Domain.Entities.Player>> {
        private IPlayerRepository _playerRepository;

        public GetLeaderboardHandler (IPlayerRepository playerRepository) {
            _playerRepository = playerRepository;
        }

        public async Task<IEnumerable<SI.Domain.Entities.Player>> Handle (GetLeaderboardRequest request, CancellationToken token) {
            var player = new SI.Domain.Entities.Player ();
            return await _playerRepository.GetTopPlayersByScoreAsync (request.ShowTop);
        }
    }
}