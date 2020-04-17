using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;

namespace SI.Application.Partners {
    public class SetIsActiveToPartnerHandler : IRequestHandler<SetIsActiveToPartnerRequest, Result> {

        IPartnerRepository _partnerRepository;

        public SetIsActiveToPartnerHandler (IPartnerRepository partnerRepository) {
            _partnerRepository = partnerRepository;
        }

        public async Task<Result> Handle (SetIsActiveToPartnerRequest req, CancellationToken token) {
            return await _partnerRepository.SetIsActive (req.ID, req.IsActive);
        }
    }
}