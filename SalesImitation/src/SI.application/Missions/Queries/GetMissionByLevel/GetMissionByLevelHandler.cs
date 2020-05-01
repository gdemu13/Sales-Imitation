using MediatR;
using SI.Common.Models;
using SI.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using SI.Domain.Abstractions.Repositories;
using System.Collections.Generic;

namespace SI.Application.Categories {
    public class GetMissionByLevelHandler : IRequestHandler<GetMissionByLevellRequest, Mission> {

        IMissionRepository _missionRepository;

        public GetMissionByLevelHandler(IMissionRepository missionRepository){
            _missionRepository = missionRepository;
        }

        public async Task<Mission> Handle(GetMissionByLevellRequest request, CancellationToken token){
           return await _missionRepository.GetByLevel(request.Level);
        }
    }
}