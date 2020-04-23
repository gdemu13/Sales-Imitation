using MediatR;
using SI.Common.Models;
using System;
using System.Collections.Generic;
using SI.Domain.Entities;

namespace SI.Application.Partners  {
    public class GetPartnerRequest : IRequest<Partner> {
        public Guid ID {get; set;}
        public GetPartnerRequest(Guid id) {
            ID = id;
        }
    }
}