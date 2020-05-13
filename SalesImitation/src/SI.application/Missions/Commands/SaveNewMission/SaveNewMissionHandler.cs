using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;

namespace SI.Application.Missions {
    public class SaveNewMissionHandler : IRequestHandler<SaveNewMissionRequest, Result> {

        IMissionRepository _missionRepository;

        public SaveNewMissionHandler (IMissionRepository missionRepository) {
            _missionRepository = missionRepository;
        }

        public async Task<Result> Handle (SaveNewMissionRequest req, CancellationToken token) {
            if (req.PriceFrom >= req.PriceTo)
                return new Result (false, "price_from_should_be_less");

            var lastUpdate = await _missionRepository.GetLastUpdateDate ();
            var lastMissionLevel = await _missionRepository.GetLastLevelNumber ();
            var missions = await _missionRepository.GetByPriceRange (req.PriceFrom, req.PriceTo);

            if (missions != null && missions.Count () != 0)
                return new Result (false, "price_overlap");

            var mission = new Mission (Guid.NewGuid(), req.Name, req.Description, lastMissionLevel + 1, req.PriceFrom, req.PriceTo);
            return await _missionRepository.InsertIfLast (mission, lastUpdate);
        }
    }
}