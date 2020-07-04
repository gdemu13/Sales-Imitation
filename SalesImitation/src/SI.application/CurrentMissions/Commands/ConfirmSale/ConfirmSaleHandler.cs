using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;
using SI.Domin.Abstractions.Authentication;

namespace SI.Application.CurrentMissions {
    public class ConfirmSaleHandler : IRequestHandler<ConfirmSaleRequest, Result>
    {
        private readonly ICurrentMissionRepository repository;
        private readonly ICurrentUser currentUser;

        public ConfirmSaleHandler(ICurrentMissionRepository repository, ICurrentUser currentUser)
        {
            this.repository = repository;
            this.currentUser = currentUser;
        }

        public async Task<Result> Handle(ConfirmSaleRequest request, CancellationToken cancellationToken)
        {
            var curMiss = await repository.GetActiveByCode(request.Code);
            curMiss.Item1.SellProduct(request.Code, request.ProductID, DateTime.Now, currentUser.ID.Value);
            return await repository.UpdateIfNotChanged(curMiss.Item1.ID, curMiss.Item1, curMiss.Item2.Value);
        }
    }
}