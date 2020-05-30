using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;
using SI.Domin.Abstractions.Authentication;

namespace SI.Application.Players
{
    public class GetLeaderboardHandler : IRequestHandler<GetLeaderboardRequest, GetLeaderboardResponse>
    {
        private IPlayerRepository _playerRepository;
        private readonly ICurrentUser currentUser;

        public GetLeaderboardHandler(IPlayerRepository playerRepository, ICurrentUser currentUser)
        {
            _playerRepository = playerRepository;
            this.currentUser = currentUser;
        }

        public async Task<GetLeaderboardResponse> Handle(GetLeaderboardRequest request, CancellationToken token)
        {
            if (request.ShowTop > 20)
                request.ShowTop = 20;
            var res = await _playerRepository.GetTopPlayersByScoreAsync(request.ShowTop);
            var result = new GetLeaderboardResponse();
            result.Others = new List<GetLeaderboardItem>();
            int place = 1;
            foreach (var n in res)
            {
                result.Others.Add(new GetLeaderboardItem
                {
                    Avatar = (int)n.Avatar,
                    coins = n.Coins,
                    Name = $"{n.Username.First()}*****{n.Username.Last()}",
                    Place = place++,
                });
            }

            var curPlayer = await _playerRepository.GetPlayerPlaceInLeaderboard(currentUser.ID.Value);
            result.You = new GetLeaderboardItem
            {
                Name = currentUser.DisplayName,
                coins = curPlayer.Item2,
                Place = curPlayer.Item1
            };
            return result;
        }
    }
}