using MediatR;
using SI.Common.Models;
using System;

namespace SI.Application.CurrentMissions {
    public class SkipCurrentMissionRequst : IRequest<Result>
    {
    }
}