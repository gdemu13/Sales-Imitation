using MediatR;
using SI.Common.Models;
using SI.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using SI.Domain.Abstractions.Repositories;
using System.Collections.Generic;

namespace SI.Application.Partners
{
    public class GetRangeOfPartnersHandler : IRequestHandler<GetRangeOfPartnersRequest, GetangeOfPartnerResponse>
    {

        IPartnerRepository _partnerRepository;

        public GetRangeOfPartnersHandler(IPartnerRepository partnerRepository)
        {
            _partnerRepository = partnerRepository;
        }

        public async Task<GetangeOfPartnerResponse> Handle(GetRangeOfPartnersRequest request, CancellationToken token)
        {
            var items = await _partnerRepository.GetRange(request.Skip, request.Take, request.SearchWord);
            int quantity = await _partnerRepository.Count(request.SearchWord);
            return new GetangeOfPartnerResponse
            {
                Items = items,
                Quantity = quantity
            };
        }
    }
}