using System;
using MediatR;
using SI.Common.Models;

namespace SI.Application.Partners {
    public class SetIsActiveToPartnerRequest : IRequest<Result> {
        public Guid ID { get; set; }
        public bool IsActive {get; set;}
    }
}
