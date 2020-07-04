using MediatR;
using SI.Common.Models;

namespace SI.Application.SuperBonuses {
    public class GetActiveBonusRequest : IRequest<SI.Domain.Entities.SuperBonus> {
    }
}