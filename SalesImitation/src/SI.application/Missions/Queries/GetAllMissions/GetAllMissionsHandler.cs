using MediatR;
using SI.Common.Models;
using SI.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using SI.Domain.Abstractions.Repositories;
using System.Collections.Generic;

namespace SI.Application.Missions {
    public class GetAllMissionsHandler : IRequestHandler<GetAllMissionsRequest, IEnumerable<Mission>> {

        IMissionRepository _missionRepository;

        public GetAllMissionsHandler(IMissionRepository missionRepository){
            _missionRepository = missionRepository;
        }

        public async Task<IEnumerable<Mission>> Handle(GetAllMissionsRequest request, CancellationToken token){
           return await _missionRepository.GetAll();
        }
    }
}