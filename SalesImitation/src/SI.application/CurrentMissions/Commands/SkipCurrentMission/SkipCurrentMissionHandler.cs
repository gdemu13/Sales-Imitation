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
using SI.Domain.Services;
using SI.Domin.Abstractions.Authentication;

namespace SI.Application.CurrentMissions
{
    public class SkipCurrentMissionHandler : IRequestHandler<SkipCurrentMissionRequst, Result>
    {
        private readonly ICurrentUser currentUser;
        private readonly IPlayerService playerService;

        public SkipCurrentMissionHandler(ICurrentUser currentUser,
                                    IPlayerService playerService)
        {
            this.currentUser = currentUser;
            this.playerService = playerService;
        }
        public async Task<Result> Handle(SkipCurrentMissionRequst request, CancellationToken cancellationToken)
        {
            return await playerService.SkipMission(currentUser.ID.Value);
        }
    }
}