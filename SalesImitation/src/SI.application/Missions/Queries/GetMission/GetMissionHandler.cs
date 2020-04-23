using MediatR;
using SI.Common.Models;
using SI.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using SI.Domain.Abstractions.Repositories;
using System.Collections.Generic;

namespace SI.Application.Missions {
    public class GetMissionHandler : IRequestHandler<GetMissionRequest, Mission> {

        IMissionRepository _missionRepository;

        public GetMissionHandler(IMissionRepository missionRepository){
            _missionRepository = missionRepository;
        }

        public async Task<Mission> Handle(GetMissionRequest request, CancellationToken token){
           return await _missionRepository.Get(request.ID);
        }
    }
}