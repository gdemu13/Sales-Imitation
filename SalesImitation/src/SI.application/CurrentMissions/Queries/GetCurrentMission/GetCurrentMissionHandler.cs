using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;
using SI.Domain.Exceptions;
using SI.Domin.Abstractions.Authentication;

namespace SI.Application.CurrentMissions
{
    public class GetCurrentMissionHandler : IRequestHandler<GetCurrentMissionRequest, CurrentMission>
    {
        private readonly ICurrentUser currentUser;
        private readonly ICurrentMissionRepository currentMissionRepository;

        public GetCurrentMissionHandler(ICurrentUser currentUser, ICurrentMissionRepository currentMissionRepository)
        {
            this.currentUser = currentUser;
            this.currentMissionRepository = currentMissionRepository;
        }

        public async Task<CurrentMission> Handle(GetCurrentMissionRequest request, CancellationToken token)
        {
            return await currentMissionRepository.GetActiveByUser(currentUser.ID.Value);
        }

        private T ChooseRandomProduct<T>(IEnumerable<T> products)
        {
            Random rand = new Random();
            return products.ToList()[rand.Next(0, products.Count() - 1)];
        }
    }
}