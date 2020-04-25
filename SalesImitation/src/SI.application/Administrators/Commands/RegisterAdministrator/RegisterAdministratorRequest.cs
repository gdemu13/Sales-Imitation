using MediatR;
using SI.Common.Models;
using System;

namespace SI.Application.Administrators  {
    public class RegisterAdministratorRequest : IRequest<Result> {
        public string UserName {get; set;}
        public string Password {get; set;}
    }
}