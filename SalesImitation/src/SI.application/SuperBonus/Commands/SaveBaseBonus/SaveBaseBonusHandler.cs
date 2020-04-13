using MediatR;
using SI.Common.Models;
using System.Threading;
using System.Threading.Tasks;
using SI.Domain.Abstractions.Repositories;

namespace SI.Application.SuperBonus {
    public class SaveBaseBonusHandler : IRequestHandler<SaveBaseBonusRequest, Result> {

        ISuperBonusRepository _bonusRepository;

        public SaveBaseBonusHandler(ISuperBonusRepository bonusReository){
            _bonusRepository = bonusReository;
        }

        public async Task<Result> Handle(SaveBaseBonusRequest request, CancellationToken token){
            var bonus = await _bonusRepository.GetPending();
            if(bonus == null)
                 return await _bonusRepository.InsertSuperBonusBase(request.ID, request.Amount);
            else
                return await _bonusRepository.UpdateSuperBonusBase(bonus.ID, request.Amount);

        }
    }
}