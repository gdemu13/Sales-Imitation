using MediatR;
using SI.Common.Models;
using SI.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using SI.Domain.Abstractions.Repositories;
using System.Collections.Generic;

namespace SI.Application.Partners {
    public class GetPartnerHandler : IRequestHandler<GetPartnerRequest, Partner> {

        IPartnerRepository _partnerRepository;

        public GetPartnerHandler(IPartnerRepository partnerRepository){
            _partnerRepository = partnerRepository;
        }

        public async Task<Partner> Handle(GetPartnerRequest request, CancellationToken token){
           return await _partnerRepository.Get(request.ID);
        }
    }
}