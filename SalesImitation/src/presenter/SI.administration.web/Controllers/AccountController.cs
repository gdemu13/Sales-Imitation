using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using SI.Domain.Entities;
using SI.Common.Models;
using SI.Application.SuperBonuses;
using System;
using MediatR;
using SI.Domin.Abstractions.Authentication;
using SI.Application.Administrators;
using Microsoft.AspNetCore.Authorization;



namespace SI.Administration.Web.Controllers
{
    [Route("/api/Account")]
    public class AccountController : ApiController
    {
        ICurrentUser _currentUser;
        public AccountController(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        [HttpGet("UserInfo")]
        public async Task<string> UserInfo()
        {
            return $"{_currentUser.ID} - {_currentUser.DisplayName}";
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<Result> Login([FromBody] LoginAdministratorRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpPost("Register")]
         [AllowAnonymous]
        public async Task<Result> Register([FromBody] RegisterAdministratorRequest request)
        {
            return await Mediator.Send(request);
        }
    }
}