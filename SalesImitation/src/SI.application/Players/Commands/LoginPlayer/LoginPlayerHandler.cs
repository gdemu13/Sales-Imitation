using MediatR;
using SI.Common.Models;
using SI.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using SI.Domain.Abstractions.Repositories;
using System.Collections.Generic;
using SI.Domin.Abstractions.Authentication;

namespace SI.Application.Players
{
    public class LoginPlayerHandler : IRequestHandler<LoginPlayerRequest, Result<LoginPlayerResponse>>
    {
        IPlayerRepository _playerRepository;
        private readonly ICurrentUser _currentUser;

        public LoginPlayerHandler(IPlayerRepository playerRepository, ICurrentUser currentUser)
        {
            _playerRepository = playerRepository;
            _currentUser = currentUser;
        }

        public async Task<Result<LoginPlayerResponse>> Handle(LoginPlayerRequest request, CancellationToken token)
        {
            var (player, _) = await _playerRepository.GetByUsername(request.UserName);
            if (player != null && player.IsPasswordValid(request.Password))
            {
                await _currentUser.SignIn(player.ID, player.Username);
                return Result<LoginPlayerResponse>.CreateSuccessReqest(new LoginPlayerResponse { UserName = player.Username });
            }
            return new Result<LoginPlayerResponse>(false, "incorect_credentials", null);
        }
    }
}