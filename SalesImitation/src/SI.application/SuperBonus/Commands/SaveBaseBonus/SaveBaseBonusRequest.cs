using MediatR;
using SI.Common.Models;
using System;

namespace SI.Application.SuperBonuses {
    public class SaveBaseBonusRequest : IRequest<Result> {
        public decimal Amount {get; set;}
    }
}