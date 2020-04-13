using MediatR;
using SI.Common.Models;

namespace SI.Application.SuperBonus {
    public class GetPendingBonusRequest : IRequest<SI.Domain.Entities.SuperBonus> {
    }
}