using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;
using System.Linq;

namespace SI.Application.Missions {
    public class SaveNewMissionHandler : IRequestHandler<SaveNewMissionRequest, Result> {

        IMissionRepository _missionRepository;

        public SaveNewMissionHandler (IMissionRepository missionRepository) {
            _missionRepository = missionRepository;
        }

        public async Task<Result> Handle (SaveNewMissionRequest req, CancellationToken token) {
            var lastUpdate  = await _missionRepository.GetLastUpdateDate ();
            var lastMissionRaund = await _missionRepository.GetLastRoundNumber ();
            var missions = await _missionRepository.GetByPriceRange (req.PriceFrom, req.PriceTo);

            if (missions != null && missions.Count () != 0)
                return new Result (false, "price_overlap");

            var mission = new Mission (req.ID, req.Name, req.Description, lastMissionRaund, req.PriceFrom, req.PriceTo);
            return await _missionRepository.InsertIfLast (mission, lastUpdate);
        }
    }
}