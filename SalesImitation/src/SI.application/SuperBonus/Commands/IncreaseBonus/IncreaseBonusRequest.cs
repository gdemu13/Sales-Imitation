using MediatR;
using SI.Common.Models;

namespace SI.Application.SuperBonuses {
    public class IncreaseBonusRequest : IRequest<Result> {
        public decimal Amount {get; set;}
    }
}