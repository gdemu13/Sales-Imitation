using MediatR;
using SI.Common.Models;

namespace SI.Application.SuperBonuses {
    public class GetPendingBonusRequest : IRequest<SI.Domain.Entities.SuperBonus> {
    }
}