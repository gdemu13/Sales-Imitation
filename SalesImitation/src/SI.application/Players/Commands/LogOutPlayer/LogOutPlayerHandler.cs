using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Common.Models;
using SI.Domin.Abstractions.Authentication;

namespace SI.Application.Players
{
    public class LogOutPlayerHandler : IRequestHandler<LogOutPlayerRequest, Result>
    {
        private readonly ICurrentUser currentUser;

        public LogOutPlayerHandler(ICurrentUser currentUser)
        {
            this.currentUser = currentUser;
        }
        public async Task<Result> Handle(LogOutPlayerRequest request, CancellationToken cancellationToken)
        {
            await currentUser.SignOut();
            return await Task.FromResult(Result.CreateSuccessReqest());
        }
    }
}