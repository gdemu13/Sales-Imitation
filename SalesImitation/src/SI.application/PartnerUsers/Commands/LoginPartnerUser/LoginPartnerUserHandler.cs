using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;
using SI.Domin.Abstractions.Authentication;

namespace SI.Application.PartnerUsers {
    public class LoginPartnerUserHandler : IRequestHandler<LoginPartnerUserRequest, Result<string>>
    {
        private readonly IPartnerUserRepository repository;
        private readonly ICurrentUser _currentUser;

        public LoginPartnerUserHandler(IPartnerUserRepository repository, ICurrentUser currentUser)
        {
            this.repository = repository;
            this._currentUser = currentUser;
        }

        public async Task<Result<string>> Handle(LoginPartnerUserRequest request, CancellationToken cancellationToken)
        {
           var partnerUser = await repository.GetByUsername(request.Username);

            if (partnerUser != null && partnerUser.IsPasswordValid(request.Password))
            {
                await _currentUser.SignIn(partnerUser.ID, partnerUser.Username, true);
                return Result<string>.CreateSuccessReqest( partnerUser.Username );
            }
            return new Result<string>(false, "მომხმარებლის სახელი ან პაროლი არასწორია", null);
        }
    }
}