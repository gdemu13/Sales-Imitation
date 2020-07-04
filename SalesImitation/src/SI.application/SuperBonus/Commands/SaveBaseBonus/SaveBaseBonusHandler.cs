using MediatR;
using SI.Common.Models;
using System.Threading;
using System.Threading.Tasks;
using SI.Domain.Abstractions.Repositories;
using System;
using SI.Domain.Entities;

namespace SI.Application.SuperBonuses {
    public class SaveBaseBonusHandler : IRequestHandler<SaveBaseBonusRequest, Result> {

        ISuperBonusRepository _bonusRepository;

        public SaveBaseBonusHandler(ISuperBonusRepository bonusReository){
            _bonusRepository = bonusReository;
        }

        public async Task<Result> Handle(SaveBaseBonusRequest request, CancellationToken token){
            var active = await _bonusRepository.GetActive();

            if(active == null)
                await _bonusRepository.InsertSuperBonusBase(new SI.Domain.Entities.SuperBonus(Guid.NewGuid(), request.Amount, SuperBonusStatuses.Active));


            var bonus = await _bonusRepository.GetPending();
            if(bonus == null)
                 return await _bonusRepository.InsertSuperBonusBase(new SI.Domain.Entities.SuperBonus(Guid.NewGuid(), request.Amount, SuperBonusStatuses.Pending));
            else
                return await _bonusRepository.UpdateSuperBonusBase(bonus.ID, request.Amount);
        }
    }
}