using MediatR;

namespace SI.Application.Players
{
    public class LoginWithFacebookRequest : IRequest<LoginWithFacebookResponse>
    {
        public string AccessToken { get; set; }
        public string UserID { get; set; }
    }
}