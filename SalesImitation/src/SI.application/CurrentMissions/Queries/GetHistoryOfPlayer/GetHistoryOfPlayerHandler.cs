using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;

namespace SI.Application.CurrentMissions {
    public class GetHistoryOfPlayerHandler : IRequestHandler<GetHistoryOfPlayerRequest, IEnumerable<CurrentMission>>
    {
        private readonly ICurrentMissionRepository repository;

        public GetHistoryOfPlayerHandler(ICurrentMissionRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<CurrentMission>> Handle(GetHistoryOfPlayerRequest request, CancellationToken cancellationToken)
        {
           return await repository.GetHistoryOfPlayer(request.PlayerID);
        }
    }
}