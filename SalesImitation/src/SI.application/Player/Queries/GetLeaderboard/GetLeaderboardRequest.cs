using MediatR;
using System.Collections.Generic;
using SI.Domain.Entities;
using SI.Domain.Abstractions.Repositories;

namespace SI.Application.Player {
    public class GetLeaderboardRequest : IRequest<IEnumerable<SI.Domain.Entities.Player>> {
        public int ShowTop {get; set;} = 10;
    }
}