using MediatR;
using SI.Common.Models;
using System.Threading;
using System.Threading.Tasks;
using SI.Domain.Abstractions.Repositories;

namespace SI.Application.SuperBonus {
    public class GetPendingBonusHandler : IRequestHandler<GetPendingBonusRequest, SI.Domain.Entities.SuperBonus> {

        ISuperBonusRepository _bonusRepository;

        public GetPendingBonusHandler(ISuperBonusRepository bonusReository){
            _bonusRepository = bonusReository;
        }

        public async Task<SI.Domain.Entities.SuperBonus> Handle(GetPendingBonusRequest request, CancellationToken token){
            return await _bonusRepository.GetPending();
        }
    }
}