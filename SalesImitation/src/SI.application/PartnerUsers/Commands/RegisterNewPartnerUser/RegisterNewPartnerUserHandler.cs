using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;

namespace SI.Application.PartnerUsers {
    public class RegisterNewPartnerUserHandler : IRequestHandler<RegisterNewPartnerUserRequest, Result>
    {
        private readonly IPartnerUserRepository repository;
        private readonly IPartnerRepository partnerRepository;

        public RegisterNewPartnerUserHandler(IPartnerUserRepository repository,
        IPartnerRepository partnerRepository)
        {
            this.repository = repository;
            this.partnerRepository = partnerRepository;
        }

        public async Task<Result> Handle(RegisterNewPartnerUserRequest request, CancellationToken cancellationToken)
        {
            var partner = await partnerRepository.Get(request.PartnerID);
            var user = new PartnerUser(
                Guid.NewGuid(),
                request.Username,
                request.Password,
                request.Fullname,
                new PartnerUserPartner(request.PartnerID,partner.Name)
            );
            return await repository.Insert(user);
        }
    }
}