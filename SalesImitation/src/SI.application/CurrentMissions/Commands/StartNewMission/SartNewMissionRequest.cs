using MediatR;
using SI.Common.Models;
using System;

namespace SI.Application.CurrentMissions {
    public class StartNewMissionRequest : IRequest<Result>
    {
        public Guid SelectedCategoryID { get;  set; }
    }
}