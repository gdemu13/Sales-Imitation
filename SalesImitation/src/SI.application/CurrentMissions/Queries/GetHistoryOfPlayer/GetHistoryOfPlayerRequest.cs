using System;
using System.Collections.Generic;
using MediatR;
using SI.Domain.Entities;

namespace SI.Application.CurrentMissions {
    public class GetHistoryOfPlayerRequest : IRequest<IEnumerable<CurrentMission>>
    {
        public GetHistoryOfPlayerRequest(Guid playerID)
        {
            PlayerID = playerID;
        }
        public Guid PlayerID { get; internal set; }
    }
}