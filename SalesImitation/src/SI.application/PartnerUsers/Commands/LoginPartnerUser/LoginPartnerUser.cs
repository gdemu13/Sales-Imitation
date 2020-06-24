using MediatR;
using SI.Common.Models;

namespace SI.Application.PartnerUsers {
    public class LoginPartnerUserRequest : IRequest<Result<string>> {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}