using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Application.Abstractions;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;
using SI.Domain.Exceptions;
using SI.Domin.Abstractions.Authentication;

namespace SI.Application.Players
{
    public class LoginWithFacebookHandler : IRequestHandler<LoginWithFacebookRequest, LoginWithFacebookResponse>
    {
        private readonly IPlayerRepository repository;
        private readonly ICurrentUser currentUser;
        private readonly IFacebookService facebookService;

        public LoginWithFacebookHandler(IPlayerRepository repository,
        ICurrentUser currentUser,
        IFacebookService facebookService)
        {
            this.repository = repository;
            this.currentUser = currentUser;
            this.facebookService = facebookService;
        }

        public async Task<LoginWithFacebookResponse> Handle(LoginWithFacebookRequest request, CancellationToken cancellationToken)
        {
            LoginWithFacebookResponse result;
            var userData = await facebookService.GetUser(request.AccessToken, request.UserID);
            if (userData.Error != null)
            {
                throw new LocalizableException("cant_authorize_with_fb", "cant_authorize_with_fb");
            }
            Player player = await repository.GetByFacebookID(request.UserID);
            if (player == null)
            {
                result = new LoginWithFacebookResponse
                {
                    RegistrationNeeded = true,
                    BirthDate = userData.BirthDate,
                    Email = userData.Email,
                    FirstName = userData.Name?.Split(' ').First(),
                    LastName = userData.Name?.Split(' ').Last(),
                    AccessToken = request.AccessToken,
                    UserID = request.UserID,
                };
            }
            else
            {
                await currentUser.SignIn(player.ID, player.Username);
                result = new LoginWithFacebookResponse
                {
                    RegistrationNeeded = false,
                    BirthDate = userData.BirthDate,
                    Email = userData.Email,
                    FirstName = userData.Name?.Split(' ').First(),
                    LastName = userData.Name?.Split(' ').Last(),
                     AccessToken = request.AccessToken,
                    UserID = request.UserID,
                };
            }
            return result;
        }
    }
}