using System;
using MediatR;
using SI.Common.Models;

namespace SI.Application.Players
{
    public class ChangePasswordRequest : IRequest<Result>
    {
        public Guid PlayerID { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}