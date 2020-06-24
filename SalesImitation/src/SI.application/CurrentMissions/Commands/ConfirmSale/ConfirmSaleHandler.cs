using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;

namespace SI.Application.CurrentMissions {
    public class ConfirmSaleHandler : IRequestHandler<ConfirmSaleRequest, Result>
    {
        private readonly ICurrentMissionRepository repository;

        public ConfirmSaleHandler(ICurrentMissionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result> Handle(ConfirmSaleRequest request, CancellationToken cancellationToken)
        {
            var curMiss = await repository.GetActiveByCode(request.Code);
            curMiss.Item1.SellProduct(request.Code, request.ProductID, DateTime.Now);
            return Result.CreateSuccessReqest();
        }
    }
}