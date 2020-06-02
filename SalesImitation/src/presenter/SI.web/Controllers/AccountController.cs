using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SI.Application.Administrators;
using SI.Application.Categories;
using SI.Application.Players;
using SI.Common.Models;
using SI.Domain.Entities;
using SI.Domin.Abstractions.Authentication;

namespace SI.Web.Controllers
{
    [Route("api/account/")]
    public class AccountController : ApiController
    {

        ICurrentUser _currentUser;
        public AccountController(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        [HttpGet("UserInfo")]
        public async Task<GetPlayerByIDResponse> UserInfo()
        {
            return await Mediator.Send(new GetPlayerByIDRequest(_currentUser.ID.Value));
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<Result> Login([FromBody] LoginPlayerRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpPost("logout")]
        [AllowAnonymous]
        public async Task<Result> Logout()
        {
            return await Mediator.Send(new LogOutPlayerRequest());
        }

        [HttpPost("Facebook")]
        [AllowAnonymous]
        public async Task<LoginWithFacebookResponse> Login([FromBody] LoginWithFacebookRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<Result> Register([FromBody] RegisterPlayerRequest request)
        {
            var res = await Mediator.Send(request);
            if (res.IsSuccess)
                res = await Mediator.Send(new LoginPlayerRequest()
                {
                    Password = request.Password,
                    UserName = request.Username,
                    StayLogedIn = true
                });
            return res;
        }
    }
}