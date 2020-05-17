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
        public async Task<Result> Login([FromBody]LoginPlayerRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<Result> Register([FromBody] RegisterPlayerRequest request)
        {
            return await Mediator.Send(request);
        }
    }
}