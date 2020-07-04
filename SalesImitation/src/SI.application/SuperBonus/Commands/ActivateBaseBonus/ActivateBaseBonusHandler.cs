using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;

namespace SI.Application.SuperBonuses {
    public class ActivateBaseBonusHandler : IRequestHandler<ActivateBaseBonusRequest, Result> {

        ISuperBonusRepository _bonusRepository;

        public ActivateBaseBonusHandler (ISuperBonusRepository bonusReository) {
            _bonusRepository = bonusReository;
        }

        public async Task<Result> Handle (ActivateBaseBonusRequest request, CancellationToken token) {
            var bonus = await _bonusRepository.GetPending ();
            if (bonus != null)
                return await _bonusRepository.UpdateStatus (bonus.ID, SuperBonusStatuses.Active);
            else
                return await Task.FromResult (Result.CreateSuccessReqest());
        }
    }
}