using MediatR;
using SI.Common.Models;
using System;

namespace SI.Application.SuperBonus {
    public class SaveBaseBonusRequest : IRequest<Result> {
        public decimal Amount {get; set;}
        public Guid ID {get; set;}
    }
}