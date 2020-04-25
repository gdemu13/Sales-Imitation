using MediatR;
using SI.Common.Models;
using SI.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using SI.Domain.Abstractions.Repositories;
using System.Collections.Generic;
using SI.Domin.Abstractions.Authentication;

namespace SI.Application.Administrators
{
    public class LoginAdministratorHandler : IRequestHandler<LoginAdministratorRequest, Result<LoginAdministratorResponse>>
    {
        IUserRepository _userRepository;
        private readonly ICurrentUser _currentUser;

        public LoginAdministratorHandler(IUserRepository userRepository, ICurrentUser currentUser)
        {
            _userRepository = userRepository;
            _currentUser = currentUser;
        }

        public async Task<Result<LoginAdministratorResponse>> Handle(LoginAdministratorRequest request, CancellationToken token)
        {
            var user = await _userRepository.GetByUserName(request.UserName);
            if (user != null && user.IsPasswordValid(request.Password))
            {
                await _currentUser.SignIn(user.ID, user.UserName);
                return Result<LoginAdministratorResponse>.CreateSuccessReqest(new LoginAdministratorResponse { UserName = user.UserName });
            }
            return new Result<LoginAdministratorResponse>(false, "incorect_credentials", null);
        }
    }
}