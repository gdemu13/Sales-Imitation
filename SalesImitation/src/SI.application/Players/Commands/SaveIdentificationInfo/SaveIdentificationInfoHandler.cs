using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;

namespace SI.Application.Players
{
    public class SaveIdentificationInfoHandler : IRequestHandler<SaveIdentificationInfoRequest, Result>
    {
        private readonly IPlayerRepository repository;

        public SaveIdentificationInfoHandler(IPlayerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result> Handle(SaveIdentificationInfoRequest request, CancellationToken cancellationToken)
        {
            var info = await repository.GetIdentificationInfo(request.PlayerID);
            var identificationInfo = info.Info;
            if (identificationInfo == null)
                identificationInfo = new IdentificationInfo(Guid.NewGuid());

            if (!string.IsNullOrEmpty(request.IDCardFrontUrl))
                identificationInfo.IDCardFrontUrl = request.IDCardFrontUrl;

            if (!string.IsNullOrEmpty(request.IDCardBackUrl))
                identificationInfo.IDCardBackUrl = request.IDCardBackUrl;

            if (!string.IsNullOrEmpty(request.SelfieUrl))
                identificationInfo.SelfieUrl = request.SelfieUrl;

            if (!string.IsNullOrEmpty(request.IDNumber))
                identificationInfo.IDNumber = request.IDNumber;

            return await repository.SaveIdentificationInfo(request.PlayerID, identificationInfo, info.Date);
        }
    }
}