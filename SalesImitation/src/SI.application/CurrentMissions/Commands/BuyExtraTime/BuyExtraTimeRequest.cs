using MediatR;
using SI.Common.Models;
using System;

namespace SI.Application.CurrentMissions {
    public class BuyExtraTimeRequest : IRequest<Result>
    {
        public int Hours { get;  set; }
    }
}