using System;
using MediatR;
using SI.Common.Models;

namespace SI.Application.Players
{
    public class ChangePasswordRequest : IRequest<Result>
    {
        public Guid PlayerID { get; internal set; }
        public string CurrentPassword { get; internal set; }
        public string NewPassword { get; internal set; }
    }
}