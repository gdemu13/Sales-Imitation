using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;

namespace SI.Application.Partners {
    public class UpdatePartnerHandler : IRequestHandler<UpdatePartnerRequest, Result> {

        IPartnerRepository _partnerRepository;

        public UpdatePartnerHandler (IPartnerRepository partnerRepository) {
            _partnerRepository = partnerRepository;
        }

        public async Task<Result> Handle (UpdatePartnerRequest req, CancellationToken token) {
            var partner = new Partner (req.ID, req.Name);

            if (!string.IsNullOrEmpty (req.LogoUrl))
                partner.Logo = new PartnerLogo (req.LogoUrl);

            partner.Address = new PartnerAddress (req.Address?.Street);
            partner.ContactInfo = new PartnerContactInfo (req.Contact?.Number, req.Contact?.Email);
            partner.ContactPerson = new PartnerContactPerson (req.ContactPerson?.FirstName,
                req.ContactPerson?.LastName,
                req.ContactPerson?.Number,
                req.ContactPerson?.Email);

            partner.WebSite = req.WebSite;

            return await _partnerRepository.Update (partner.ID, partner);
        }
    }
}