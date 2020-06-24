using System;
using MediatR;
using SI.Common.Models;

namespace SI.Application.PartnerUsers
{
    public class RegisterNewPartnerUserRequest : IRequest<Result>
    {
        public string Username { get; set;}
        public string Password { get;  set; }
        public string Fullname { get; set; }
        public Guid PartnerID { get; set; }
    }
}