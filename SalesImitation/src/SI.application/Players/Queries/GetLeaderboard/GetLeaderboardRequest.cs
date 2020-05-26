using MediatR;
using System.Collections.Generic;
using SI.Domain.Entities;
using SI.Domain.Abstractions.Repositories;

namespace SI.Application.Players {
    public class GetLeaderboardRequest : IRequest<GetLeaderboardResponse> {
        public int ShowTop {get; set;}
    }
}