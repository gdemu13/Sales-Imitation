using MediatR;
using SI.Common.Models;
using SI.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using SI.Domain.Abstractions.Repositories;
using System.Collections.Generic;

namespace SI.Application.Categories
{
    public class GetPlayerByIDHandler : IRequestHandler<GetPlayerByIDRequest, Player>
    {
        IPlayerRepository _playerRepository;

        public GetPlayerByIDHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<Player> Handle(GetPlayerByIDRequest request, CancellationToken token)
        {
            var (player, _) = await _playerRepository.GetByID(request.ID);
            return player;
        }
    }
}