using MediatR;
using SI.Common.Models;
using System;
using System.Collections.Generic;
using SI.Domain.Entities;

namespace SI.Application.Administrators  {
    public class LoginAdministratorRequest : IRequest<Result<LoginAdministratorResponse>> {
        public string UserName {get; set;}
        public string Password {get; set;}
    }
}