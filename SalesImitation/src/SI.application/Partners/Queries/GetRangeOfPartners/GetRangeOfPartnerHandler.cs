using MediatR;
using SI.Common.Models;
using SI.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using SI.Domain.Abstractions.Repositories;
using System.Collections.Generic;

namespace SI.Application.Partners {
    public class GetRangeOfPartnersHandler : IRequestHandler<GetRangeOfPartnersRequest, IEnumerable<Partner>> {

        IPartnerRepository _partnerRepository;

        public GetRangeOfPartnersHandler(IPartnerRepository partnerRepository){
            _partnerRepository = partnerRepository;
        }

        public async Task<IEnumerable<Partner>> Handle(GetRangeOfPartnersRequest request, CancellationToken token){
           return await _partnerRepository.GetRange(request.Skip, request.Take);
        }
    }
}