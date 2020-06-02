using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;
using System.Linq;

namespace SI.Application.Missions {
    public class UpdateMissionHandler : IRequestHandler<UpdateMissionRequest, Result> {

        IMissionRepository _missionRepository;

        public UpdateMissionHandler (IMissionRepository missionRepository) {
            _missionRepository = missionRepository;
        }

        public async Task<Result> Handle (UpdateMissionRequest req, CancellationToken token) {
            var lastUpdate  = await _missionRepository.GetLastUpdateDate ();
            var prevMission = await _missionRepository.Get (req.ID);
            var missions = await _missionRepository.GetByPriceRange (req.PriceFrom, req.PriceTo);

            if (missions != null && missions.Count (m => m.ID != req.ID) != 0)
                return new Result (false, "price_overlap");

            var mission = new Mission (req.ID, req.Name, req.Description, prevMission.Level, req.DurationInHours, req.PriceFrom, req.PriceTo);
            return await _missionRepository.Update (req.ID, mission, lastUpdate);
        }
    }
}