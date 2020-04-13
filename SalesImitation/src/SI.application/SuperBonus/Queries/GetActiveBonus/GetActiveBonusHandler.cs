using MediatR;
using SI.Common.Models;
using System.Threading;
using System.Threading.Tasks;
using SI.Domain.Abstractions.Repositories;

namespace SI.Application.SuperBonus {
    public class GetActiveBonusHandler : IRequestHandler<GetActiveBonusRequest, SI.Domain.Entities.SuperBonus> {

        ISuperBonusRepository _bonusRepository;

        public GetActiveBonusHandler(ISuperBonusRepository bonusReository){
            _bonusRepository = bonusReository;
        }

        public async Task<SI.Domain.Entities.SuperBonus> Handle(GetActiveBonusRequest request, CancellationToken token){
            return await _bonusRepository.GetActive();
        }
    }
}