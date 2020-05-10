using MediatR;
using SI.Common.Models;
using SI.Domain.Entities;
using System;

namespace SI.Application.CurrentMissions {
    public class GetCurrentMissionRequest : IRequest<CurrentMission>
    {
    }
}