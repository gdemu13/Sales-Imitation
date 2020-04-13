using MediatR;
using SI.Common.Models;

namespace SI.Application.SuperBonus {
    public class GetActiveBonusRequest : IRequest<SI.Domain.Entities.SuperBonus> {
    }
}