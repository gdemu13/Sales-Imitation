using System;
using MediatR;
using SI.Common.Models;

namespace SI.Application.Players
{
    public class RegisterPlayerRequest : IRequest<Result>
    {
        public string Username { get; set;}
        public string Password { get; set;}
        public string Mail { get; set;}
        public string Firstname { get;set; }
        public string Lastname { get; set;}
    }
}