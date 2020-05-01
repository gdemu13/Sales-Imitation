using MediatR;
using SI.Common.Models;
using System;
using System.Collections.Generic;
using SI.Domain.Entities;

namespace SI.Application.Players  {
    public class LoginPlayerRequest : IRequest<Result<LoginPlayerResponse>> {
        public string UserName {get; set;}
        public string Password {get; set;}
    }
}