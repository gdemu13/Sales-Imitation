using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using SI.Domain.Entities;
using SI.Common.Models;
using SI.Application.SuperBonus;
using System;
using MediatR;
using SI.Domin.Abstractions.Authentication;
using SI.Application.Administrators;



namespace SI.Administration.Web.Controllers
{
    [Route("/api/Account")]
    public class AccountController : ControllerBase
    {
       private IMediator _mediator;

        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator> ());
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
        public async Task<Result> Login([FromBody]LoginAdministratorRequest request)
        {
            return await Mediator.Send (request);
        }

         [HttpPost("Register")]
    public async Task<Result> Register([FromBody]RegisterAdministratorRequest request)
        {
             return await Mediator.Send (request);
        }
    }
}